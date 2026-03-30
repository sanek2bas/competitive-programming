from pathlib import Path
import psycopg2 as pc

database_url = "postgresql://postgres:postgres@localhost:8080/test"

def read_sql_file(file_path):
    with open(file_path, 'r') as file:
        sql_query = file.read()
    return sql_query

def get_connection():
    return pc.connect(database_url)