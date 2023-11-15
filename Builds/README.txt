# Build Updates
- Change Events' default duration from 5 to 10 Seconds.
- Increase Button Event Speed.
- Add button in Event Screen to Change Event Default Speed and Duration
- Update [README.txt].


build from 

----------------------------------------------------------------------------------------------------
-------------------------------- !!!!! READ ME [README.txt] !!!!! ---------------------------------
----------------------------------------------------------------------------------------------------

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
