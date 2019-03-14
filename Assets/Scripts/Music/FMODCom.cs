using UnityEngine;

public class FMODCom {
    private FMOD.Studio.EventInstance FMODEvent;
    FMOD.Studio.PLAYBACK_STATE playbackState;

    public FMODCom(string eventName) {
        FMODEvent = FMODUnity.RuntimeManager.CreateInstance("event:/" + eventName);
    }

    public void Play3D(Transform transform, Rigidbody rb) {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(FMODEvent, transform, rb);
        Play();
    }

    public void SetParameter(string name, float amt) {
        Debug.Log("DOESN'T WORK, FIX THIS! :D");
        FMOD.Studio.ParameterInstance par;
        Play();
    }

    public void Play() {
        FMODEvent.getPlaybackState(out playbackState);
        if (playbackState != FMOD.Studio.PLAYBACK_STATE.STOPPED) return;
        FMODEvent.start();
    }
}