import common

try:
    init_query = common.read_sql_file("init.sql")
    solution_query = common.read_sql_file("solution.sql")

    connection = common.get_connection()
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