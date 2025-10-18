# Task Tracker

A command-line application for tracking and managing your tasks (to-do list).

🎯 Overview

This project implements a CLI tool that allows you to:

Add, update, and delete tasks.

Mark tasks as “In Progress”, “Done” or "Not Started".

List all tasks, or filter by status (Not Started, In Progress, Done).

Persist tasks to a JSON file in the local filesystem.
The project follows the requirements from the “Task Tracker” challenge on roadmap.sh. 
https://roadmap.sh/projects/task-tracker

✅ Features

add — Adds a new task with the given description.

update — Updates the description of the task with the given ID.

delete — Deletes the task with the given ID.

list all tasks - List all tasks in the json file.

list done tasks - List all done tasks.

list not started tasks - List all not started tasks.

list in progress tasks - List all in progress tasks.


🧠 Task Properties

Each task stored in the JSON file has the following properties:

id: Unique identifier for the task.

description: A short description of the task.

status: The current status of the task (Not Started, In Progress, Done).

createdAt: Timestamp when the task was created.

updatedAt: Timestamp of the last update to the task.
