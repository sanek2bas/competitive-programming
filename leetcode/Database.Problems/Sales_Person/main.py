from pathlib import Path
import psycopg2 as pc

database_url = "postgresql://postgres:postgres@localhost:8080/test"

def read_sql_file(filename):
    base_dir = Path(__file__).resolve().parent
    file_path = base_dir / filename
    with open(file_path, 'r') as file:
        sql_query = file.read()
    return sql_query

try:
    init_query = read_sql_file("init.sql")
    solution_query = read_sql_file("solution.sql")

    connection = pc.connect(database_url)
    cursor = connection.cursor()

    cursor.execute(init_query)
    connection.commit()

    cursor.execute(solution_query)
    connection.commit()

    rows = cursor.fetchall()
    for row in rows:
        print(row)

    cursor.close()
except Exception as e:
    print(f'Error: {e}')
finally:
    if connection:
        connection.close()