SELECT Today.id
FROM Weather as Today
INNER JOIN Weather AS Yesterday
    ON Today.recordDate - INTERVAL '1 day' = Yesterday.recordDate
WHERE Today.temperature > Yesterday.temperature;