# Build Updates
- Fix LeaderBoard and DashBoard Rnaking Flash problem.
- Improve the Accuracy of the LeaderBoard's Ranking.
- Change Events' default duration to 10 Seconds.

# Dev Updates
- Add more Checkpoints for Ranking Updates (from 8 to 14)
- Upgrade LeaderBoard Background to auto fit the number of Columns


build from 

---------------------------------------------------------------------------------------------------

# [README.txt]

### 【Basic Camera Movement】
[1] Free Move from current position (Default)
[2-9] Fixed Camera Positions
[0] Top View
[W/A/S/D + Mouse X/Y] Move Position and Facing Position
[Left Shift] Move Faster
[Space] Go Higher
[Left Control] Go lower

### 【Menus HotKeys】
[P] Pause/Continue Game
[H] Toggle (Open/Close) Score Ranking Dashboard
[E] Open Events Menu (will Pause Game)
[Tab] Open Score Dashboard (will Pause Game)

### 【Event Buttons】

### Event-1 (Enter an Integer)
Team names longer than entered Integer will reduce speed within 10 seconds.

- Enter `length`  will `speed - 20` for `10` Time Unit.
`[length] : Any Integer`


### Event-2 (Enter a Color)
Selected Car Color will increase speed within 10 seconds.

- Enter `color`  will `speed + 20` for `10` Time Unit.
`[color] : orange || black || yellow || blue || white || purple || green || red`


### Event-3 (Enter a Color)
Selected Car Color will reduce speed within 10 seconds.

- Enter `color`  will `speed - 20` for `10` Time Unit.
`[color] : orange || black || yellow || blue || white || purple || green || red`


### Event-4 (Enter a Integer)
Cars equipped with inputed index of Function will increase speed within 10 seconds.

- Car with `Function_Dictionary[Int]` will `speed + 20` for `10` Time Unit.
`[Function_Dictionary] : {
        {1, "male" },
        {2, "glasses" },
        {3, "facerecog" },
        {4, "language" },
        {5, "password" },
        {6, "distance" }
}`


### Event-5 (Enter a Integer)
Cars equipped with inputed index of Function will reduce speed within 10 seconds.

- Car with `Function_Dictionary[Int]` will `speed + 20` for `10` Time Unit.
`[Function_Dictionary] : {
        {1, "male" },
        {2, "glasses" },
        {3, "facerecog" },
        {4, "language" },
        {5, "password" },
        {6, "distance" }
}`


### Event-6 (Snow Event)
Will activate Snow Weather Environment.


### Event-7 (Night Event)
Will activate Night Weather Environment.
