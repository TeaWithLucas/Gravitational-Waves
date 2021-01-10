using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI {
    [RequireComponent(typeof(Text))]
    public class UIAssets : MonoBehaviour {

        Text text;

        // Start is called before the first frame update
        void Start() {
            text = GetComponent<Text>();
            //text.text = ItemManager.DispItems();
            //text.text = AssetManager.Assets();
            text.text = AssetManager.Assets();
        }

        // Update is called once per frame
        void Update() {

        }
    }
}