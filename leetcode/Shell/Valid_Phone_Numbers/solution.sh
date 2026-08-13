#!/bin/bash

phonePattern='^(\d{3}-|\(\d{3}\) )\d{3}-\d{4}$'
grep -P "$phonePattern" file.txt