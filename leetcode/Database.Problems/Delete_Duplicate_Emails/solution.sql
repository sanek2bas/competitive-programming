DELETE FROM Person personA 
USING Person personB
WHERE personA.id > personB.id 
  AND personA.email = personB.email;

SELECT * 
FROM Person;