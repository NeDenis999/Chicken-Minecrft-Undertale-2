﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class UIPanelStateController : MonoBehaviour
    {
        [SerializeField]
        private List<UIPanelState> _panels;
        
        private UIPanelState _activePanel;

        public UIPanelStateType ActiveStateType => _activePanel.GetUIPanelStateType();

        private void Awake()
        {
            _activePanel = GetPanelByType(UIPanelStateType.Menu);
            _activePanel.Activate(true);
        }

        public void SetPanelState(UIPanelStateType uIPanelStateType)
        {
            _activePanel.Activate(false);
            var newPanel = GetPanelByType(uIPanelStateType);
            _activePanel = newPanel;
            newPanel.Activate(true);
        }

        private UIPanelState GetPanelByType(UIPanelStateType uIPanelStateType)
        {
            return _panels.First(x => x.GetUIPanelStateType() == uIPanelStateType);
        }
    }
}