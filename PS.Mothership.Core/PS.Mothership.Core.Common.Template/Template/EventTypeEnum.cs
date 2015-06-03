using System;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;
using PS.Mothership.Core.Common.Template.Gen;

namespace PS.Mothership.Core.Common.Template.Event
{
    
    [DataContract]
    public enum EventTypeEnum : int
    {
       [Description("None")][EnumMember]None = 0,
       [Description("SMS Scheduled")][EnumMember]SMSScheduled = 1,
       [Description("SMS Sent")][EnumMember]SMSSent = 2,
       [Description("SMS Received")][EnumMember]SMSReceived = 3,
       [Description("SMS Send Failed")][EnumMember]SMSSendFailed = 4,
       [Description("SMS Delivered")][EnumMember]SMSDelivered = 5,
       [Description("Email Scheduled")][EnumMember]EmailScheduled = 6,
       [Description("Email Sent")][EnumMember]EmailSent = 7,
       [Description("Email Received")][EnumMember]EmailReceived = 8,
       [Description("EmailSendFailed")][EnumMember]EmailSendFailed = 9,
       [Description("Dialler Call Made")][EnumMember]DiallerCallMade = 10,
       [Description("Dialler Call Recording")][EnumMember]DiallerCallRecording = 11,
       [Description("Notification Scheduled")][EnumMember]NotificationScheduled = 12,
       [Description("Notification Actioned")][EnumMember]NotificationActioned = 13,
       [Description("Application Created")][EnumMember]ApplicationCreated = 14,
       [Description("Application Updated")][EnumMember]ApplicationUpdated = 15,
       [Description("Application Abandoned")][EnumMember]ApplicationAbandoned = 16,
       [Description("Opportunity Created")][EnumMember]OpportunityCreated = 17,
       [Description("Opportunity Updated")][EnumMember]OpportunityUpdated = 18,
       [Description("Opportunity Abandoned")][EnumMember]OpportunityAbandoned = 19,
       [Description("Offer Created")][EnumMember]OfferCreated = 20,
       [Description("Touch Merchant")][EnumMember]TouchMerchant = 21,
       [Description("Prospect Imported")][EnumMember]ProspectImported = 22,
       [Description("Campaign Queue Item Added")][EnumMember]CampaignQueueItemAdded = 23,
       [Description("Campaign Queue Item Removed")][EnumMember]CampaignQueueItemRemoved = 24,
       [Description("Campaign Queue Item Updated")][EnumMember]CampaignQueueItemUpdated = 25,
       [Description("Queue Item Added")][EnumMember]QueueItemAdded = 26,
       [Description("Queue Item Removed")][EnumMember]QueueItemRemoved = 27,
       [Description("Queue Item Updated")][EnumMember]QueueItemUpdated = 28,
       [Description("Prospect Deduped")][EnumMember]ProspectDeduped = 29,
       [Description("Scheduled Callback")][EnumMember]ScheduledCallback = 30,
       [Description("1 Hr")][EnumMember]OneHour = 31,
       [Description("2 Hr")][EnumMember]TwoHours = 32,
       [Description("24 Hr")][EnumMember]OneDay = 33,
       [Description("48 Hr")][EnumMember]TwoDays = 34,
       [Description("1 Wk")][EnumMember]OneWeek = 35,
       [Description("2 Wk")][EnumMember]TwoWeeks = 36,
       [Description("Custom")][EnumMember]Custom = 37,
       [Description("Callback Queued")][EnumMember]CallbackQueued = 38,
       [Description("Callback Fired")][EnumMember]CallbackFired = 39,
       [Description("Callback AutoRescheduled")][EnumMember]CallbackAutoRescheduled = 40,
       [Description("Callback Accepted")][EnumMember]CallbackAccepted = 41,
       [Description("Pop Up")][EnumMember]PopUpReminderAdded = 42,
       [Description("SMS")][EnumMember]SMSReminderAdded = 43,
       [Description("Merchant Note Added")][EnumMember]MerchantNoteAdded = 44,
       [Description("Reminder Added")][EnumMember]ReminderAdded = 45,
       [Description("ReminderQueued")][EnumMember]ReminderQueued = 46,
       [Description("ReminderFired")][EnumMember]ReminderFired = 47,
       [Description("ReminderNotAcknowledged")][EnumMember]ReminderNotAcknowledged = 48,
       [Description("Call Resolved")][EnumMember]CallResolved = 49,
        
    }    
    
    public class EventType
    {
        public int EnumValue {get;set;}
		public string EnumName {get;set;}
		public string EnumDescription {get;set;}
		public int EventTypeKey {get;set;}
		public int EventCategoryKey {get;set;}
		public GenRecStatusEnum RecStatusKey {get;set;}
    }

    /// <summary>
    /// This class is mainly for using the extended properties of Enum
    /// </summary>
    public static class EventTypeCollection
    {
        private static List<EventType> _list; 
        public static List<EventType> EventTypeList
        {
            get
            {
                if (_list == null)
                {   
                        _list = new List<EventType>
                        {
                            new EventType
							{
								EnumValue = 0,
								EnumName = "None",
								EnumDescription = "None",
								EventTypeKey = 0,
								EventCategoryKey = 0,
								RecStatusKey = (GenRecStatusEnum)0
							},
							new EventType
							{
								EnumValue = 1,
								EnumName = "SMSScheduled",
								EnumDescription = "SMS Scheduled",
								EventTypeKey = 1,
								EventCategoryKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 2,
								EnumName = "SMSSent",
								EnumDescription = "SMS Sent",
								EventTypeKey = 2,
								EventCategoryKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 3,
								EnumName = "SMSReceived",
								EnumDescription = "SMS Received",
								EventTypeKey = 3,
								EventCategoryKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 4,
								EnumName = "SMSSendFailed",
								EnumDescription = "SMS Send Failed",
								EventTypeKey = 4,
								EventCategoryKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 5,
								EnumName = "SMSDelivered",
								EnumDescription = "SMS Delivered",
								EventTypeKey = 5,
								EventCategoryKey = 13,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 6,
								EnumName = "EmailScheduled",
								EnumDescription = "Email Scheduled",
								EventTypeKey = 6,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 7,
								EnumName = "EmailSent",
								EnumDescription = "Email Sent",
								EventTypeKey = 7,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 8,
								EnumName = "EmailReceived",
								EnumDescription = "Email Received",
								EventTypeKey = 8,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 9,
								EnumName = "EmailSendFailed",
								EnumDescription = "EmailSendFailed",
								EventTypeKey = 9,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 10,
								EnumName = "DiallerCallMade",
								EnumDescription = "Dialler Call Made",
								EventTypeKey = 10,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 11,
								EnumName = "DiallerCallRecording",
								EnumDescription = "Dialler Call Recording",
								EventTypeKey = 11,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 12,
								EnumName = "NotificationScheduled",
								EnumDescription = "Notification Scheduled",
								EventTypeKey = 12,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 13,
								EnumName = "NotificationActioned",
								EnumDescription = "Notification Actioned",
								EventTypeKey = 13,
								EventCategoryKey = 1,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 14,
								EnumName = "ApplicationCreated",
								EnumDescription = "Application Created",
								EventTypeKey = 14,
								EventCategoryKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 15,
								EnumName = "ApplicationUpdated",
								EnumDescription = "Application Updated",
								EventTypeKey = 15,
								EventCategoryKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 16,
								EnumName = "ApplicationAbandoned",
								EnumDescription = "Application Abandoned",
								EventTypeKey = 16,
								EventCategoryKey = 5,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 17,
								EnumName = "OpportunityCreated",
								EnumDescription = "Opportunity Created",
								EventTypeKey = 17,
								EventCategoryKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 18,
								EnumName = "OpportunityUpdated",
								EnumDescription = "Opportunity Updated",
								EventTypeKey = 18,
								EventCategoryKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 19,
								EnumName = "OpportunityAbandoned",
								EnumDescription = "Opportunity Abandoned",
								EventTypeKey = 19,
								EventCategoryKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 20,
								EnumName = "OfferCreated",
								EnumDescription = "Offer Created",
								EventTypeKey = 20,
								EventCategoryKey = 6,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 21,
								EnumName = "TouchMerchant",
								EnumDescription = "Touch Merchant",
								EventTypeKey = 21,
								EventCategoryKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 22,
								EnumName = "ProspectImported",
								EnumDescription = "Prospect Imported",
								EventTypeKey = 22,
								EventCategoryKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 23,
								EnumName = "CampaignQueueItemAdded",
								EnumDescription = "Campaign Queue Item Added",
								EventTypeKey = 23,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 24,
								EnumName = "CampaignQueueItemRemoved",
								EnumDescription = "Campaign Queue Item Removed",
								EventTypeKey = 24,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 25,
								EnumName = "CampaignQueueItemUpdated",
								EnumDescription = "Campaign Queue Item Updated",
								EventTypeKey = 25,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 26,
								EnumName = "QueueItemAdded",
								EnumDescription = "Queue Item Added",
								EventTypeKey = 26,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 27,
								EnumName = "QueueItemRemoved",
								EnumDescription = "Queue Item Removed",
								EventTypeKey = 27,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 28,
								EnumName = "QueueItemUpdated",
								EnumDescription = "Queue Item Updated",
								EventTypeKey = 28,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 29,
								EnumName = "ProspectDeduped",
								EnumDescription = "Prospect Deduped",
								EventTypeKey = 29,
								EventCategoryKey = 7,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 30,
								EnumName = "ScheduledCallback",
								EnumDescription = "Scheduled Callback",
								EventTypeKey = 30,
								EventCategoryKey = 8,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 31,
								EnumName = "OneHour",
								EnumDescription = "1 Hr",
								EventTypeKey = 31,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 32,
								EnumName = "TwoHours",
								EnumDescription = "2 Hr",
								EventTypeKey = 32,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 33,
								EnumName = "OneDay",
								EnumDescription = "24 Hr",
								EventTypeKey = 33,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 34,
								EnumName = "TwoDays",
								EnumDescription = "48 Hr",
								EventTypeKey = 34,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 35,
								EnumName = "OneWeek",
								EnumDescription = "1 Wk",
								EventTypeKey = 35,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 36,
								EnumName = "TwoWeeks",
								EnumDescription = "2 Wk",
								EventTypeKey = 36,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 37,
								EnumName = "Custom",
								EnumDescription = "Custom",
								EventTypeKey = 37,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 38,
								EnumName = "CallbackQueued",
								EnumDescription = "Callback Queued",
								EventTypeKey = 38,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new EventType
							{
								EnumValue = 39,
								EnumName = "CallbackFired",
								EnumDescription = "Callback Fired",
								EventTypeKey = 39,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new EventType
							{
								EnumValue = 40,
								EnumName = "CallbackAutoRescheduled",
								EnumDescription = "Callback AutoRescheduled",
								EventTypeKey = 40,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new EventType
							{
								EnumValue = 41,
								EnumName = "CallbackAccepted",
								EnumDescription = "Callback Accepted",
								EventTypeKey = 41,
								EventCategoryKey = 9,
								RecStatusKey = (GenRecStatusEnum)2
							},
							new EventType
							{
								EnumValue = 42,
								EnumName = "PopUpReminderAdded",
								EnumDescription = "Pop Up",
								EventTypeKey = 42,
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)3
							},
							new EventType
							{
								EnumValue = 43,
								EnumName = "SMSReminderAdded",
								EnumDescription = "SMS",
								EventTypeKey = 43,
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)3
							},
							new EventType
							{
								EnumValue = 44,
								EnumName = "MerchantNoteAdded",
								EnumDescription = "Merchant Note Added",
								EventTypeKey = 44,
								EventCategoryKey = 12,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 45,
								EnumName = "ReminderAdded",
								EnumDescription = "Reminder Added",
								EventTypeKey = 45,
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 46,
								EnumName = "ReminderQueued",
								EnumDescription = "ReminderQueued",
								EventTypeKey = 46,
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 47,
								EnumName = "ReminderFired",
								EnumDescription = "ReminderFired",
								EventTypeKey = 47,
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 48,
								EnumName = "ReminderNotAcknowledged",
								EnumDescription = "ReminderNotAcknowledged",
								EventTypeKey = 48,
								EventCategoryKey = 10,
								RecStatusKey = (GenRecStatusEnum)1
							},
							new EventType
							{
								EnumValue = 49,
								EnumName = "CallResolved",
								EnumDescription = "Call Resolved",
								EventTypeKey = 49,
								EventCategoryKey = 14,
								RecStatusKey = (GenRecStatusEnum)1
							},
                        };
                    
                }
                return _list;
            }

        }
    }
   
}
