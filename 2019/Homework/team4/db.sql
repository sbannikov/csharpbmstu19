-- DROP TABLE IF EXISTS Sources, Sensors, Parameters, Vals;
CREATE TABLE IF NOT EXISTS Sources (
    source_uuid   VARCHAR(36) PRIMARY KEY, -- Уникальный идентификатор источника выбросов
    pniv          INT, -- Порядковый номер источника выбросов
    last_changed  TIMESTAMP DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS Sensors (
    sensor_uuid   VARCHAR(36) PRIMARY KEY,-- Уникальный идентификатор датчика
    parent_source_uuid VARCHAR(36) REFERENCES Sources(source_uuid),
    state         VARCHAR(11), -- Состояние датчика OK | ERROR | MAINTENANCE
    last_changed  TIMESTAMP DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS Parameters (
    parameter_uuid VARCHAR(36) PRIMARY KEY, -- Уникальный идентификатор показания
    parent_sensor_uuid VARCHAR(36) REFERENCES Sensors(sensor_uuid),
    code          VARCHAR(20), -- Тип показания
    unit          VARCHAR(10), -- Единица измерения показания
    type          VARCHAR(6), -- Тип данных показания
    last_changed TIMESTAMP DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS Vals (
    value_uuid    VARCHAR(36) PRIMARY KEY, -- Уникальный идентификатор значения показания
    parent_parameter_uuid VARCHAR(36) REFERENCES Parameters(parameter_uuid),
    timestamp_start INT, -- Отметка времени начала усреднения значения показания
    timestamp_end INT, -- Отметка времени окончания усреднения значения показания
    value         VARCHAR(20), -- Значение показания
    last_changed TIMESTAMP DEFAULT NOW()
);

INSERT INTO Sources(source_uuid, pniv) 
VALUES
    ('1659c3c8-e887-4b73-bee7-b1cabf2cc8e9', 1);

INSERT INTO Sensors(sensor_uuid, parent_source_uuid, state)
VALUES
    ('bbc5c3fe-0368-466f-8d7f-efffed500fa2', '1659c3c8-e887-4b73-bee7-b1cabf2cc8e9', 'OK'),
    ('bbc5c3fe-0368-466f-8d7f-kekkekkekkek', '1659c3c8-e887-4b73-bee7-b1cabf2cc8e9', 'OK');

INSERT INTO Parameters(parameter_uuid, parent_sensor_uuid, code, unit, type) 
VALUES
    ('1e95b92e-16e4-42d9-b739-ecf6d827285c', 'bbc5c3fe-0368-466f-8d7f-efffed500fa2', 'HClkgPerHour', 'kgPH', 'float'),
    ('1e95b92e-16e4-42d9-b739-lollollollol', 'bbc5c3fe-0368-466f-8d7f-efffed500fa2', 'SO2kgPerHour', 'kgPH', 'float');

INSERT INTO Vals(value_uuid, parent_parameter_uuid, timestamp_start, timestamp_end, value, last_changed) 
VALUES
    ('4885a599-bb6d-4af0-89cd-1f2be320b56f', '1e95b92e-16e4-42d9-b739-ecf6d827285c', 1559313898, 1559315098, '1.35', CURRENT_TIMESTAMP),
    ('4885a599-bb6d-4af0-89cd-olololololo1', '1e95b92e-16e4-42d9-b739-lollollollol', 1559313898, 1559315098, '1.35', '2014-04-04 20:32:59.390583+02'),
    ('4885a599-bb6d-4af0-89cd-olololololo2', '1e95b92e-16e4-42d9-b739-lollollollol', 1559313898, 1559315098, '1.50', CURRENT_TIMESTAMP);

DROP VIEW IF EXISTS latestVals, allvaluesjion;

CREATE VIEW allvaluesjion AS
SELECT source_uuid, pniv, sensor_uuid, state, parameter_uuid, code, unit, type, timestamp_start, timestamp_end, value, vls.last_changed
FROM Vals vls
JOIN Parameters prm
    ON vls.parent_parameter_uuid = prm.parameter_uuid
JOIN Sensors sns
    ON sns.sensor_uuid = prm.parent_sensor_uuid
JOIN Sources srs
    ON srs.source_uuid = sns.parent_source_uuid
;

CREATE VIEW latestVals AS
SELECT DISTINCT ON (source_uuid, sensor_uuid, parameter_uuid, code) *
FROM allvaluesjion
ORDER BY source_uuid, sensor_uuid, parameter_uuid, code, last_changed DESC
;
