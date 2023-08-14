#!/bin/bash

STARTDIR=`pwd`
CUSER=`whoami`

# check to make sure we are in repo root (unless you change the folder name)
if [[ "$STARTDIR" =~ .*\/augmented-gem$ ]]
then
  echo "In git root folder. Continuing."
else
  echo "Not in git root folder. Exiting."
  exit
fi

# relative to repo root
ARTASSETS="./gem/Assets/"
GDRIVE="../gamejam_gdrive/"

GITDATE=`date +"%y-%m-%d-%H%M"`
BRANCHNAME="auto/art-$GITDATE"

git checkout main
git stash
git stash drop
git pull
git checkout -b $BRANCHNAME

# get the files from google drive.
# rclone is a program that needs some one-time setup
rclone sync -v --create-empty-src-dirs "gamejam_art:Gamejam 2023" $STARTDIR/$GDRIVE

# sync between the directories
rsync -av --include "*/" --include="*.png" --include="*.wav" --exclude="*" $STARTDIR/$GDRIVE $STARTDIR/$ARTASSETS

git add .
git commit -m "Auto-update of art assets by $CUSER's computer"

git push --set-upstream origin $BRANCHNAME

