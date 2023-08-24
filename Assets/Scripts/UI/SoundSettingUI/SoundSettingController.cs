using CosmicCuration.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.UI
{
    public class SoundSettingController
    {
        private SoundSettingView UIView;

        public SoundSettingController(SoundSettingView soundSettingView)
        {
            UIView = soundSettingView;
            UIView.SetController(this);
        }

        public void DisableView() => UIView.gameObject.SetActive(false);

        public void EnableView() => UIView.gameObject.SetActive(true);

        public void OnClickSoundBtn()=> GameService.Instance.GetSoundService().ToggleGameplaySoundEffectsState();

        public void OnClickMusicBtn()=> GameService.Instance.GetSoundService().ToggleBGMState();
 
        public void OnClickBackBtn()
        {
            DisableView();
            GameService.Instance.GetUIService().EnableOptionsScreen();
        }
    }
}
