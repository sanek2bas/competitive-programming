import os
import sys
from pathlib import Path

current_dir = Path(__file__).resolve().parent
parent_folder = current_dir.parent
sys.path.insert(0, str(parent_folder))

from utils import *

init_sql_path = os.path.join(current_dir, 'init.sql')
solution_sql_path = os.path.join(current_dir, 'solution.sql')

execute_sql_files(init_sql_path, solution_sql_path);