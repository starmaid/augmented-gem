#!/bin/bash

# relative to repo root
ARTASSETS="./gem/Assets/Art/"
GDRIVE="../gamejam_art/"

STARTDIR=`pwd`

# get the files from google drive.
# rclone is a program that needs some one-time setup
rclone sync -v --create-empty-src-dirs "gamejam_art:Gamejam 2023" $STARTDIR/$GDRIVE

# sync between the directories
rsync -av --include "*/" --include="*.png" --include="*.wav" --exclude="*" $STARTDIR/$GDRIVE $STARTDIR/$ARTASSETS

