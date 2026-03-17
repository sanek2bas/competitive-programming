import os
import psycopg2 as pc

database_url = "postgresql://postgres:postgres@localhost:8080/test"

def read_sql_file(filename):
    cwd = os.getcwd()
    abs_path = os.path.realpath(filename)
    base_dir = os.path.dirname(abs_path)
    file_path = os.path.join(base_dir, filename)
    with open(file_path, 'r') as file:
        sql_query = file.read()
    return sql_query

try:
    query_init = read_sql_file("init.sql")
    with pc.connect(database_url) as conn:
        print("connection succesful")
        cursor = conn.cursor

        cursor.execute(query_init)
        conn.commit()

        cursor.execute("SELECT * FROM SalesPerson")
        print(cursor.fetchall())

        cursor.close()
        conn.close()
except Exception as e:
    print(f'Error: {e}')

print('Hello world')