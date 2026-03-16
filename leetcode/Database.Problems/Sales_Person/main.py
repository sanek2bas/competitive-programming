import psycopg2 as pc

database_url = "postgresql://postgres:postgres@localhost:8080/test"

try:
    with pc.connect(database_url) as conn:
        print("connection succesful")
except Exception as e:
    print(f'Error: {e}')


print('Hello world')