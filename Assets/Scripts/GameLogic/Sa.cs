﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    /**
     * Sa stands for "Static Assets"
     * this class provides refactorable references to the assets in /Resources/
     */
    public class Sa: MonoBehaviour
    {
        public AudioMap audioMap;
        public GuiControl gui;
        /** TODO: i suppose move them into GuiControl */
        public Dropdown dropdown;
        public GameObject dropdownEl;

        private static Sa inst;

        public static Sa Inst()
        {
            // should be _the only_ instantiation from /Resources/ call in the project
            // for it is the root resource provider, rest should be accessed through it
            return inst ?? (inst = ((GameObject)GameObject.Instantiate (Resources.Load("staticAssets"))).GetComponent<Sa> ());
        }
    }
}
