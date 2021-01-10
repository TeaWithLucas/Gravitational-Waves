using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using Game.Extensions;

namespace Game.Managers {
    public static class AssetManager {

        public static List<Texture2D> Textures { get; private set; }
        public static List<Sprite> Sprites { get; private set; }
        public static List<TMP_FontAsset> Fonts { get; private set; }
        public static List<TextAsset> Texts { get; private set; }


        public static bool Ready { get; private set; }
        static AssetManager() {
            Debug.Log("Loading AssetManager");
            Textures = new List<Texture2D>();
            Sprites = new List<Sprite>();
            Fonts = new List<TMP_FontAsset>();
            Texts = new List<TextAsset>();
            InitTextures();
            InitAllSprites();
            InitFontAssets();
            InitTextAssets();



            Ready = true;

        }

        public static void Load() { }

        private static void InitTextures() {
            List<string> log = new List<string>();
            foreach (Texture2D texture in Resources.LoadAll("Images", typeof(Texture2D))) {
                Textures.Add(texture);
                string name = texture.name != "" ? string.Format("{0}-tex", texture.name) : string.Format("Sprite-{0}", Sprites.Count);
                log.Add(texture.name);
                Sprite sprite = UnityEngine.Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                sprite.name = name;
                Sprites.Add(sprite);
            }
            Debug.LogFormat("Textures: {0}", log.Commaise());

        }

        private static void InitAllSprites() {
            List<string> log = new List<string>();
            foreach (Sprite asset in Resources.FindObjectsOfTypeAll<Sprite>()) {
                log.Add(asset.name);
                Sprites.Add(asset);
            }
            Debug.LogFormat("Sprites: {0}", log.Commaise());
        }

        private static void InitFontAssets() {
            List<string> log = new List<string>();
            foreach (TMP_FontAsset asset in Resources.FindObjectsOfTypeAll<TMP_FontAsset>()) {
                log.Add(asset.name);
                Fonts.Add(asset);
            }
            Debug.LogFormat("Fonts: {0}", log.Commaise());
        }

        private static void InitTextAssets() {
            List<string> log = new List<string>();
            foreach (TextAsset asset in Resources.LoadAll("", typeof(TextAsset))) {
                log.Add(asset.name);
                Texts.Add(asset);
            }
            Debug.LogFormat("Texts: {0}", log.Commaise());
        }

        public static Texture2D Texture(string name) {
            if (!Textures.Any(x => x.name.ToLower() == name.ToLower())) {
                Debug.LogWarningFormat("No Texture Found Named: {0}", name);
            }
            return Textures.DefaultIfEmpty(Textures[0]).First(x => x.name.ToLower() == name.ToLower());
        }

        public static Sprite Sprite(string name) {
            if (Sprites.Any(x => x == null)) {
                Debug.LogWarning("Null found in sprites, spring cleaning...");
                Sprites = Sprites.Where(x => x != null).ToList();
            }

            if (!Sprites.Any(x => x.name?.ToLower() == name.ToLower())) {
                Debug.LogWarningFormat("No Sprite Found Named: {0}", name);
            }

            return Sprites.DefaultIfEmpty(Sprites[0]).FirstOrDefault(x => x.name.ToLower() == name.ToLower());

        }
        public static TMP_FontAsset Font(string name) {
            if (!Fonts.Any(x => x.name.ToLower() == name.ToLower())) {
                Debug.LogWarningFormat("No Font Found Named: {0}", name);
            }
            return Fonts.DefaultIfEmpty(Fonts[0]).FirstOrDefault(x => x.name.ToLower() == name.ToLower());
        }
        public static TextAsset Text(string name) {
            if (!Texts.Any(x => x.name.ToLower() == name.ToLower())) {
                Debug.LogWarningFormat("No Font Found Named: {0}", name);
            }
            return Texts.DefaultIfEmpty(Texts[0]).FirstOrDefault(x => x.name.ToLower() == name.ToLower());
        }

        public static string Assets() {
            return Sprites.Select(x => x.name).Commaise();
        }
    }
}