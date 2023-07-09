using System;
using TMPro;
using UnityEngine;
using static GMTK2023.Game.TimeUtil;

namespace GMTK2023.Game
{
    public class QuestAbandonedDisplay : MonoBehaviour
    {
        [SerializeField] private float hideTimeInSeconds;

        private TMP_Text label = null!;
        private TimeSpan lastMessageTime;

        private TimeSpan HideTime => TimeSpan.FromSeconds(hideTimeInSeconds);


        private void Update()
        {
            var elapsed = TimeSinceUnityStart - lastMessageTime;
            label.enabled = elapsed < HideTime;
        }

        private void OnQuestAbandoned(IQuestTracker.QuestAbandonedEvent e)
        {
            var miniGame = e.Quest.MiniGame;
            var text = $"Attention!\n{e.Adventurer.Info.Title} could not {miniGame.ActivityDescription} because {miniGame.AbandonmentReason}";
            lastMessageTime = TimeSinceUnityStart;
            label.text = text;
        }

        private void Awake()
        {
            label = GetComponent<TMP_Text>();
            label.text = "";
            Singleton.TryFind<IQuestTracker>()!.QuestAbandoned += OnQuestAbandoned;
        }
    }
}