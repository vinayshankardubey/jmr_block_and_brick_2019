// Copyright (c) 2020 JioGlass. All Rights Reserved.

using UnityEngine;
using UnityEngine.Events;
using JMRSDK.InputModule;
using UnityEngine.SceneManagement;
namespace JMRSDK.Toolkit.UI

{
    [RequireComponent(typeof(JMRInteractable))]
    public class JMRUIButton : MonoBehaviour
    {
        #region Events
        /// <summary>
        /// Exposed event on unity inspector for user to directly drag drop objects.
        /// This event will get triggered on button click.
        /// </summary>
        public UnityEvent onButtonClick;
        #endregion

        #region Private Properties

        //Cache interactable property.
        private JMRInteractable interactable;
        //Check if component is disabled or enabled.
        private bool isEnabled;

        public bool isPlaying = true;

        #endregion

        public GameObject tutorialPanel;

        #region Mono
        private void Start()
        {
            interactable = gameObject.GetComponent<JMRInteractable>();
            interactable.InputClicked += OnButtonClick;
            interactable.OnEnableChange += OnEnableChange;
            isEnabled = interactable.IsEnabled;
        }

        private void OnDestroy()
        {
            if (interactable)
            {
                interactable.InputClicked -= OnButtonClick;
                interactable.OnEnableChange -= OnEnableChange;
            }
        }

        #endregion

        #region Events Action

        private void OnEnableChange(bool obj)
        {
            isEnabled = obj;
        }

       

        private void OnButtonClick()
        {
if(gameObject.name.ToString() == "JMRUIButtonTutorial"){
                       tutorialPanel.SetActive(true);

                
            }

           if(gameObject.name.ToString() == "JMRUIButtonPLAY"){
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            }


            if(gameObject.name.ToString() == "JMRUIButtonEXIT"){
                Application.Quit();
            }


        if(gameObject.name.ToString() == "JMRUIButtonRESUME"){
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            }

        if(gameObject.name.ToString() == "JMRUIButtonBack"){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }

            if(gameObject.name.ToString() == "JMRUIButtonJMRUIButtonPause"){
         
                  GameObject.Find("JMRUICanvasPause").active = false;

          



            }

        if(gameObject.name.ToString() == "CloseTutorial"){
        tutorialPanel.SetActive(false);
            }

            if (!isEnabled)
                return;

            onButtonClick?.Invoke();
        }
        #endregion
    }
}
