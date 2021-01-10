using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Game.UI.UIFunctions;
using static Game.UI.UITemplates;

namespace Game.UI.Templates {
    public class UITabs : MonoBehaviour {
        public ScrollRect ScrollView { get; protected set; }
        public GameObject Viewport { get; protected set; }
        public GameObject Content { get; protected set; }

        public List<UITab> Tabs { get; protected set; }

        public UITab Selected { get; protected set; }

        public GameObject Navigation { get; protected set; }
        public GameObject SliderNavPanel { get; protected set; }
        public Slider SliderNav { get; protected set; }



        public GameObject ButtonNavPanel { get; protected set; }
        public List<UIButton> ButtonsTabs { get; protected set; }

        public bool Active {
            get { return gameObject.activeSelf; }
            set { if (gameObject.activeSelf != value) gameObject.SetActive(value); }
        }

        public bool Ready { get; protected set; }

        void OnEnable() {
            if (!Ready) {
                Construct();
                Ready = true;
            }

        }

        protected void Construct() {
            //Debug.LogFormat("Constructing {0}", this);
            AddLayout(gameObject, Layouts.Vertical);
            Tabs = new List<UITab>();
            CreateView();
            CreateTabNav();
        }

        protected void CreateView() {
            ScrollView = CreateScrollView("Scroll View", gameObject);
            AddLayoutElement(ScrollView.gameObject, new Vector2(-1, 100));
            ScrollView.horizontal = false;

            Viewport = ScrollView.transform.GetChild(0).gameObject;
            Content = Viewport.transform.GetChild(0).gameObject;
            AddLayout(Content, Layouts.Vertical);
            AddSizeFitter(Content, ContentSizeFitter.FitMode.Unconstrained, ContentSizeFitter.FitMode.PreferredSize);
        }

        protected void CreateTabNav() {
            ButtonsTabs = new List<UIButton>();
            Navigation = CreatePanel("Tab Navigation", gameObject, Layouts.Vertical);
            AddLayoutElement(Navigation, new Vector2(-1, 50), new Vector2(-1, 50));

            SliderNavPanel = CreatePanel("Slider Navigation", Navigation, Layouts.Vertical);
            SliderNav = CreateSlider("Slider Navigation", SliderNavPanel);

            AddSliderListener(SliderNav, Select);

            ButtonNavPanel = CreatePanel("Button Navigation", Navigation, Layouts.Horizontal);
        }

        // Start is called before the first frame update
        void Start() {
            Select(Tabs[0]);
        }

        // Update is called once per frame
        void Update() {

        }

        public UITab AddTab<T>(string name) where T : UITab {
            UITab tab = CreatePanel(name, Content, false).AddComponent<T>();
            Tabs.Add(tab);
            ButtonsTabs.Add(tab.CreateTabButton(ButtonNavPanel, Select));
            SliderSettings(SliderNav, true, 0.5f, Tabs.Count + 0.5f);
            //tab.Active = false;
            //if (Tabs.Count == 1) {
            //    Select(Tabs[0]);
            //}
            return tab;
        }

        public UITab AddTab(UITab tab) {
            tab.transform.SetParent(Content.transform);

            return tab;
        }

        public void Select(float value) {
            Select(Tabs[(int)value - 1]);
        }

        public void Select(UITab tab) {
            if (Selected != null) {
                Selected.Button.Interactable = true;
            }
            Selected = tab;
            Selected.Button.Interactable = false;
            Tabs.ForEach(x => { x.Active = x == tab ? true : false; });
            //ButtonsTabs.ForEach(x => { x.Interactable = x == tab.Button ? false : true; });
            SliderNav.value = Tabs.IndexOf(tab) + 1;
        }
    }
}