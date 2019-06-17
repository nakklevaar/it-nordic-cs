-- Fill some data
-- 1
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-111111111111',
	'ContactId_1',
	'2020-01-01 00:00:00 +00:00',
	'Message_1',
	0,
	'2019-01-01 00:00:00 +00:00',
	'2019-01-01 00:00:00 +00:00')
-- 2
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-222222222222',
	'ContactId_2',
	'2020-02-02 00:00:00 +00:00',
	'Message_2',
	1,
	'2029-02-02 00:00:00 +00:00',
	'2029-02-02 00:00:00 +00:00')
-- 3
INSERT INTO [dbo].[ReminderItem] (
	[Id],
	[ContactId],
	[TargetDate],
	[Message],
	[StatusId],
	[CreatedDate],
	[UpdatedDate]) 
VALUES (
	'00000000-0000-0000-0000-333333333333',
	'ContactId_3',
	'2020-03-03 00:00:00 +00:00',
	'Message_3',
	1,
	'2039-03-03 00:00:00 +00:00',
	'2039-03-03 00:00:00 +00:00')
