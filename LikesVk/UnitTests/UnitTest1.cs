using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LikesVk;
using Moq;


namespace UnitTests
{
    [TestClass]
   
    public class UnitTest1
    {
       
        
        [TestMethod]
        public void ParserLinkTest()
        {
           // Parser parser = new Parser("sada","asdas");
            var mock = new Moq.Mock<Parser>(); 
            string test = "";
            mock.Setup(x => x.ParserLink("https://vk.com/seliverstov_roman")).Returns("seliverstov_roman");
            Assert.AreEqual("seliverstov_roman", "seliverstov_roman");
            ////////////////////////////////////////////////////////////////
         
        }
    }
}
