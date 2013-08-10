﻿using System;
using System.Linq;
using StarryEyes.Anomaly.TwitterApi.Rest;
using StarryEyes.Models.Accounting;
using StarryEyes.Models.Backstages.NotificationEvents;
using StarryEyes.Settings;

namespace StarryEyes.Models.Receivers.ReceiveElements
{
    public class HomeTimelineReceiver : CyclicReceiverBase
    {
        private readonly TwitterAccount _account;

        public HomeTimelineReceiver(TwitterAccount account)
        {
            this._account = account;
        }

        protected override int IntervalSec
        {
            get { return Setting.RESTReceivePeriod.Value; }
        }

        protected override async void DoReceive()
        {
            try
            {
                var recv = await this._account.GetHomeTimeline(100);
                recv.ForEach(ReceiveInbox.Queue);
            }
            catch (Exception ex)
            {
                BackstageModel.RegisterEvent(
                    new OperationFailedEvent("タイムラインを受信できません(@" +
                                             this._account.UnreliableScreenName + "): " +
                                             ex.Message));
            }
        }
    }
}
