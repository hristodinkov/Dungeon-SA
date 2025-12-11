using UnityEngine;

/// <summary>
/// Play VFX when the event bus publishes a SkillUsedEvent(a scriptable object)
/// </summary>
public class SkillVFXController : MonoBehaviour
{
    public void OnSkillUsed(EventData eventData)
    {
        SkillEventData skillEventData = (SkillEventData)eventData;
        ParticleSystem skillVFX = Instantiate(skillEventData.skillData.vfx);
        skillVFX.transform.position = skillEventData.skillCaster.transform.position;
        skillVFX.Play();
        Destroy(skillVFX.gameObject, skillVFX.main.duration);
    }
}
