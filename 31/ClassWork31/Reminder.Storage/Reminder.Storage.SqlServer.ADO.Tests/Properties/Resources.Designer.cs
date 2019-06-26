﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reminder.Storage.SqlServer.ADO.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Reminder.Storage.SqlServer.ADO.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [dbo].[ReminderItem] (
        ///	[Id],
        ///	[ContactId],
        ///	[TargetDate],
        ///	[Message],
        ///	[StatusId],
        ///	[CreatedDate],
        ///	[UpdatedDate]) 
        ///VALUES (
        ///	&apos;00000000-0000-0000-0000-111111111111&apos;,
        ///	&apos;ContactId_1&apos;,
        ///	&apos;2020-01-01 00:00:00 +00:00&apos;,
        ///	&apos;Message_1&apos;,
        ///	0,
        ///	&apos;2019-01-01 00:00:00 +00:00&apos;,
        ///	&apos;2019-01-01 00:00:00 +00:00&apos;)
        ///.
        /// </summary>
        internal static string Data {
            get {
                return ResourceManager.GetString("Data", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -- drop foreign key
        ///IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[dbo].[ReminderItem]&apos;) AND type in (N&apos;U&apos;))
        ///	ALTER TABLE [dbo].[ReminderItem] DROP CONSTRAINT IF EXISTS [FK_ReminderItem_StatusId]
        ///GO
        ///--
        ///-- (Re-)create [dbo].[ReminderItem]
        ///IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[dbo].[ReminderItem]&apos;) AND type in (N&apos;U&apos;))
        ///	DROP TABLE [dbo].[ReminderItem]
        ///GO
        ///CREATE TABLE [dbo].[ReminderItem] (
        ///	[Id] UNIQUEIDENTIFIER NOT NULL,
        ///	[ContactId] VARCHAR(50) N [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Schema {
            get {
                return ResourceManager.GetString("Schema", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DROP PROCEDURE IF EXISTS [dbo].[AddReminderItem]
        ///GO
        ///CREATE PROCEDURE [dbo].[AddReminderItem] (
        ///	@contactId AS VARCHAR(50),
        ///	@targetDate AS DATETIMEOFFSET,
        ///	@message AS VARCHAR(200),
        ///	@status AS TINYINT,
        ///	@reminderId AS UNIQUEIDENTIFIER OUTPUT
        ///)
        ///AS BEGIN
        ///	SET NOCOUNT ON
        ///
        ///	DECLARE
        ///		@now AS DATETIMEOFFSET,
        ///		@tempReminderId AS UNIQUEIDENTIFIER
        ///	
        ///	SELECT 
        ///		@now = SYSDATETIMEOFFSET(),
        ///		@tempReminderId = NEWID(); 
        ///
        ///	INSERT INTO [dbo].[ReminderItem](
        ///		[Id],
        ///		[ContactId],
        ///		[TargetDate], [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SPs {
            get {
                return ResourceManager.GetString("SPs", resourceCulture);
            }
        }
    }
}
