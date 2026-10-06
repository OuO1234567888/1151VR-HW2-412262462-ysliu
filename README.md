1. 專案截圖
![image](https://github.com/OuO1234567888/1151VR-HW2-412262462-ysliu/blob/main/1151VR-HW2-%E6%88%AA%E5%9C%96.png)

2. github連結
https://github.com/OuO1234567888/1151VR-HW2-412262462-ysliu

3. youtube連結
https://youtu.be/FsVkyHK1I68

4. 說明製作流程和相關操作
在Asset Store下載遊戲素材，將素材的Pixel Per Unit調成16，利用Tilemap放置遊戲場景的地板並加入Tilemap collider2d，在場地中央放置紅寶石當存檔點，橘寶石當終點，在玩家角色的動畫中加入bool的isMove變數控制跑步動畫，在玩家的Box Collider2D的Material放入一個摩擦力為0的Physics Material防止玩家卡在牆上，建立PlayerControl.cs控制玩家角色，建立Camera.cs讓鏡頭適當跟隨玩家，建立RetryBtn.cs在遊戲結束時可以重新載入場景。

建立Tilemap: 在Hierarchy右鍵->2D Object->Tilemap->Rectangular，在Scene 視窗裡會多一個Open Tile Palette，打開後把素材拖進去就可以在場景中使用。
