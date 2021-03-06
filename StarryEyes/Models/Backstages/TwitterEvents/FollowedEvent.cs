﻿using StarryEyes.Anomaly.TwitterApi.DataModels;

namespace StarryEyes.Models.Backstages.TwitterEvents
{
    public class FollowedEvent : TwitterEventBase
    {
        public FollowedEvent(TwitterUser source, TwitterUser target)
            : base(source, target) { }

        public override string Title
        {
            get { return "FOLLOWED"; }
        }

        public override string Detail
        {
            get { return Source.ScreenName + " -> " + TargetUser.ScreenName; }
        }
    }
}
