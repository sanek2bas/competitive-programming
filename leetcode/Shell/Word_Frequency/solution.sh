#!/bin/bash

grep -o '[a-z]\+' words.txt | \
    sort | \
    uniq -c | \
    sort -rn | \
    awk '{print $2 " " $1}'
