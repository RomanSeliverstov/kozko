using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication6;

namespace VkUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        wall Wall = new wall(true);
        [TestMethod]
        public void TestMyId()
        {
            var id = Wall.getMyId("https://vk.com/seliverstov_roman");
            Assert.AreEqual("30326937", id);
        }

        [TestMethod]
        public void TestFriendsIds()
        {
            
            int[] testFriendsIds = new int[6] {5356439,8191948,8784559,11773257,12027935,13197420};
            var friendsIds = Wall.getFriendsId("30326937");
            CollectionAssert.AreEqual(friendsIds, testFriendsIds);
        }

     }
}
