
namespace MonsterGame
{
    class Points
    {
        public int CurrentLevel;

        public Point[] PointArray;

        public Points(Map map, int currentLevel) {
            PointArray = new Point[currentLevel];
            CurrentLevel = currentLevel;
            for (int i=0; i < currentLevel; i++) {
                PointArray[i] = new Point(map);
            }
        }

        public void Draw() {
            for (int i=0; i < PointArray.Length; i++) {
                PointArray[i].Draw();
            }
        }
    }
}
