using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication6;

namespace VkUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Wall Wall = new Wall(new TestVkResponse());
        [TestMethod]
        public void TestMyId()
        {
            var userId = Wall.ParseVkLink("https://vk.com/seliverstov_roman");
            Assert.AreEqual("30326937", userId);
        }

        [TestMethod]
        public void TestFriendsIds()
        {
            
            int[] testFriendsIds = new int[6] {5356439,8191948,8784559,11773257,12027935,13197420};
            var friendsIds = Wall.GetIdsFriends("30326937");
            CollectionAssert.AreEqual(friendsIds, testFriendsIds);
        }

        [TestMethod]
        public void TestGetMaxLike()
        {

            int[] usersIds = new int[5] {38010036, 40349766, 40511435, 42208446, 43153393};
            string friendsIds = Wall.GetMaxLike(usersIds);
            string result = "38010036_23172 Количество: 3";
            Assert.AreEqual(friendsIds,result);
        }
        

     }
}
