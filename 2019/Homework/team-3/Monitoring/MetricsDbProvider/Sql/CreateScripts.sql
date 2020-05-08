create table [Source] (
	[SourceUuid] nvarchar(255) primary key,
	[Pniv] int not null
)

create table [Sensor] (
	[SensorUuid] nvarchar(255) primary key,
	[State] nvarchar(64) not null,
  [SourceId] nvarchar(255) not null,
  foreign key (SourceId) references source(SourceUuid)
)

create table [Metrics] (
	[ParameterUuid] nvarchar(255) primary key,
	[Code] nvarchar(128) not null,
	[Unit] nvarchar(32) not null,
	[Type] nvarchar(32) not null,
  [SensorId]  nvarchar(255) not null,
  foreign key (SensorId) references sensor(SensorUuid)
)

create table [Mark] (
	[ValueUuid] nvarchar(255) primary key,
	[TimestampStart] int not null,
	[TimestampEnd] int not null,
	[Value] nvarchar(64) not null,
  [ParameterId] nvarchar(255),
  foreign key ([ParameterId]) references metrics([ParameterUuid])
)