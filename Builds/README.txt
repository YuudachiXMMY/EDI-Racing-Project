# Build Updates
- Fixed several Problems
- Add DataTool.exe to Auto-Parse Vehicle data

build from 9483b8ad74e462d7b5424d87099620b786b8dae0

----------------------------------------------------------------------------------------------------
-------------------------------- !!!!! READ ME [README.txt] !!!!! ---------------------------------
----------------------------------------------------------------------------------------------------

# [README.txt]

### Car Number : Color Mapping
- 0 : green
- 1 : black
- 2 : red
- 3 : blue
- 4 : white
- 5 : yellow (Debug Use ONLY)

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
[N] Show/Hide Group Names of the cars

### 【Event Buttons】
Not Avaible Yet

### Speed: (on the Right-Bottom)
Will change Default Event Speed. Influence Both Speed Boost or Penalty.

- Influence variable DEFAULT_SPEED`.
- Default Value is `40`.
- Not recommand to Boost Speed over 70.

### Duration: (on the Right-Bottom)
Will change Default Event Duration. Influence Both Speed Boost or Penalty.

- Influence variable `DEFAULT_DURATION`.
- Default Value is `10`.

### Event-1 (Enter an Integer)
Team names longer than entered Integer will reduce speed for 10 (Default) seconds.

- Enter `length`  will `speed - DEFAULT_SPEED` for `DEFAULT_DURATION` Time Unit.
`[length] : Any Integer`


### Event-2 (Enter a Color)
Selected Car Color will increase speed for 10 (Default) seconds.

- Enter `color`  will `speed + DEFAULT_SPEED` for `DEFAULT_DURATION` Time Unit.
`[color] :  green || black || red || blue || white`


### Event-3 (Enter a Color)
Selected Car Color will reduce speed for 10 (Default) seconds.

- Enter `color`  will `speed - DEFAULT_SPEED` for `DEFAULT_DURATION` Time Unit.
`[color] : green || black || red || blue || white`


### Event-4 (Enter a Integer)
Cars equipped with inputed index of Function will increase speed for 10 (Default) seconds.

- Car with `Function_Dictionary[Int]` will `speed + DEFAULT_SPEED` for `DEFAULT_DURATION` Time Unit.
`[Function_Dictionary] : {
        {1, "male" },
        {2, "glasses" },
        {3, "facerecog" },
        {4, "language" },
        {5, "password" },
        {6, "distance" }
}`


### Event-5 (Enter a Integer)
Cars equipped with inputed index of Function will reduce speed for 10 (Default) seconds.

- Car with `Function_Dictionary[Int]` will `speed + DEFAULT_SPEED` for `DEFAULT_DURATION` Time Unit.
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
