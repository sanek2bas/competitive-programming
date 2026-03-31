import os
import sys
from pathlib import Path

current_dir = Path(__file__).resolve().parent
parent_folder = current_dir.parent
sys.path.insert(0, str(parent_folder))

from utils import *

try:
    init_sql_path = os.path.join(current_dir, 'init.sql')
    init_query = read_sql_file(init_sql_path)
    solution_sql_path = os.path.join(current_dir, 'solution.sql')
    solution_query = read_sql_file(solution_sql_path)

    connection = get_connection()
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