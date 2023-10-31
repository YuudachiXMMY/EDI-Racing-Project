# Build Updates
Demo Build with more Events
- Add a total of 7 Button Events
- Updated Hotkeys : Dashboard Menu `Tab` and Pause `P`
- Add Hotkeys : `H` Toggle Ranking Dashboard

# Dev Updates
- Fixed Event Trigger not Detectable (commit: 79fa540)
- Improve Event Triggering Algorithm
- Improve Screen
- Change Score Dashboard Ranking based on Time arrived at Checkpoints

build from https://github.com/YuudachiXMMY/Diversity-Vehicle-Project/commit/

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
Team names longer than entered Integer will reduce speed within 2 seconds.

- Enter `length`  will `speed - 20` for `2` Time Unit.
`[length] : Any Integer`


### Event-2 (Enter a Color)
Selected Car Color will increase speed within 2 seconds.

- Enter `color`  will `speed + 20` for `2` Time Unit.
`[color] : yellow || black || orange || blue || purple || red`


### Event-3 (Enter a Color)
Selected Car Color will reduce speed within 2 seconds.

- Enter `color`  will `speed - 20` for `2` Time Unit.
`[color] : yellow || black || orange || blue || purple || red`


### Event-4
Cars equipped with Facial Recognition and Fingerprint Detection will increase speed within 2 seconds.

- Car with `functionList` will `speed + 20` for `2` Time Unit.
`[functionList] : FacialRecognition || FingerprintDetection`


### Event-5
Cars that are equipped with Facial Recognition and Fingerprint Detection will reduce speed within 2 seconds.

- Car with `functionList` will `speed - 20` for `2` Time Unit.
`[functionList] : FacialRecognition || FingerprintDetection`


### Event-6 (Snow Event) - Currently NOT AVAILBE
Cars NOT Equiped with Winter Tire will reduce speed during the event.

- Car without `functionList` will `speed - 20` for `SNOW`.
`[functionList] : WinterTire`


### Event-7 (Night Event) - Currently NOT AVAILBE
Cars Equiped with Assisted Night Vision will increase speed during the event.

- Car with `functionList` will `speed + 20` for `NIGHT`.
`[functionList] : AssistedNightVision`
