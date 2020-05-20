using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImgSavTest : MonoBehaviour {

    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Text text;
    [SerializeField] Image img;

    // Use this for initialization
    void Start () {
        button1.onClick.AddListener (Button1Click);
        button2.onClick.AddListener (Button2Click);
        button3.onClick.AddListener (Button3Click);
        button4.onClick.AddListener (Button4Click);
    }
    void Button1Click () {
        // Take a screenshot and save it to Gallery/Photos
        StartCoroutine (TakeScreenshotAndSave ());
    }

    void Button2Click () {
        // Don't attempt to pick media from Gallery/Photos if
        // another media pick operation is already in progress
        if (NativeGallery.IsMediaPickerBusy ())
            return;

        // Pick a PNG image from Gallery/Photos
        // If the selected image's width and/or height is greater than 512px, down-scale the image
        PickImage (512);
    }

    void Button3Click () {
        // Don't attempt to pick media from Gallery/Photos if
        // another media pick operation is already in progress
        if (NativeGallery.IsMediaPickerBusy ())
            return;

        // Pick a video from Gallery/Photos
        PickVideo ();
    }

    void Button4Click () {
        // Don't attempt to pick media from Gallery/Photos if
        // another media pick operation is already in progress
        if (NativeGallery.IsMediaPickerBusy ())
            return;

        // Pick a video from Gallery/Photos
        PickVideo ();
    }

    private  RawImage   head;  
    public void TakePhoto (int maxSize = -1)   {     //调用插件自带接口，拉取相册，内部有区分平台
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery ((path) =>     {      
            Debug.Log ("Image path: " + path);      
            if (path != null)       {         // 此Action为选取图片后的回调，返回一个Texture2D 
                        
                Texture2D texture = NativeGallery.LoadImageAtPath (path, maxSize);        
                if (texture == null)         {          
                    Debug.Log ("Couldn't load texture from " + path);          
                    return;        
                }        
                Debug.Log (texture.name);       
                head.texture = texture; //将选择的图片对我们的RawImage进行赋值
                Sprite sprite = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), new Vector2 (0.5f, 0.5f));
                img.sprite = sprite;
                // img.tex = head.texture;
            }    
        }, "选择图片", "image/png", maxSize);
    }

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            if (Input.mousePosition.x < Screen.width / 3) {
                // Take a screenshot and save it to Gallery/Photos
                StartCoroutine (TakeScreenshotAndSave ());
            } else {
                // Don't attempt to pick media from Gallery/Photos if
                // another media pick operation is already in progress
                if (NativeGallery.IsMediaPickerBusy ())
                    return;

                if (Input.mousePosition.x < Screen.width * 2 / 3) {
                    // Pick a PNG image from Gallery/Photos
                    // If the selected image's width and/or height is greater than 512px, down-scale the image
                    PickImage (512);
                } else {
                    // Pick a video from Gallery/Photos
                    PickVideo ();
                }
            }
        }
    }

    private IEnumerator TakeScreenshotAndSave () {
        yield return new WaitForEndOfFrame ();

        Texture2D ss = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply ();

        // Save the screenshot to Gallery/Photos
        Debug.Log ("Permission result: " + NativeGallery.SaveImageToGallery (ss, "GalleryTest", "My img {0}.png"));
        text.text = "Permission result: " + NativeGallery.SaveImageToGallery (ss, "GalleryTest", "My img {0}.png");
        // To avoid memory leaks
        Destroy (ss);
    }

    private void PickImage (int maxSize) {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery ((path) => {
            Debug.Log ("Image path: " + path);

            if (path != null) {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath (path, maxSize);
                if (texture == null) {
                    Debug.Log ("Couldn't load texture from " + path);
                    text.text = "Couldn't load texture from " + path;
                    return;
                }

                // Assign texture to a temporary quad and destroy it after 5 seconds
                GameObject quad = GameObject.CreatePrimitive (PrimitiveType.Quad);
                quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                quad.transform.forward = Camera.main.transform.forward;
                quad.transform.localScale = new Vector3 (1f, texture.height / (float) texture.width, 1f);

                Material material = quad.GetComponent<Renderer> ().material;
                if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                    material.shader = Shader.Find ("Legacy Shaders/Diffuse");

                material.mainTexture = texture;

                Destroy (quad, 5f);

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                Destroy (texture, 5f);
            }
        }, "Select a PNG image", "image/png",maxSize); // 

        Debug.Log ("Permission result: " + permission);
        text.text = "Permission result: " + permission;
    }

    private void PickVideo () {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery ((path) => {
            Debug.Log ("Video path: " + path);
            if (path != null) {
                // Play the selected video
                Handheld.PlayFullScreenMovie ("file://" + path);
            }
        }, "Select a video");

        Debug.Log ("Permission result: " + permission);
    }

}