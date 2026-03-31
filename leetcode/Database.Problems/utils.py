import psycopg2 as pc

_database_url = "postgresql://postgres:postgres@localhost:8080/test"

def execute_sql_files(init_sql_path, solution_sql_path):
    try:
        init_query = _read_sql_file(init_sql_path)
        solution_query = _read_sql_file(solution_sql_path)

        connection = _get_connection()
        cursor = connection.cursor()

        _execute_sql(connection, cursor, init_query);
        _execute_sql(connection, cursor, solution_query);

        rows = cursor.fetchall()
        for row in rows:
            print(row)

        cursor.close()

    except Exception as e:
        print(f'Error: {e}')

    finally:
        if connection:
            connection.close()

def _execute_sql(connection, cursor, query):
    cursor.execute(query)
    connection.commit()    

def _read_sql_file(file_path):
    with open(file_path, 'r') as file:
        sql_query = file.read()
    return sql_query

def _get_connection():
    return pc.connect(_database_url)