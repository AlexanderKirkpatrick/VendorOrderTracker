using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorOrderTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {

    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test Vendor", "test notes");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      Vendor newVendor = new Vendor("Test Vendor", "Test Notes"); 
      Assert.AreEqual("Test Vendor", newVendor.Name);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      Vendor newVendor = new Vendor("Test Vendor", "Test Notes");

      int result = newVendor.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {

      Vendor newVendor1 = new Vendor("Test Vendor", "Test Notes");
      Vendor newVendor2 = new Vendor("Vendors Test", "Notes Test");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
      CollectionAssert.AreEqual(newList, Vendor.GetAll());
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      Vendor newVendor1 = new Vendor("Test Vendor", "Test Notes");
      Vendor newVendor2 = new Vendor("Vendors Test", "Notes Test");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
       Assert.AreEqual(newVendor2, Vendor.Find(2));

    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      Vendor newVendor1 = new Vendor("Test Vendor", "Test Notes");
      Vendor newVendor2 = new Vendor("Vendors Test", "Notes Test");
      Order newOrder = new Order("Test Vendor", "Test Notes", "44", "45", "Feb");
      List<Order> newList = new List<Order> { newOrder };
      newVendor1.AddOrder(newOrder);

      CollectionAssert.AreEqual(newList, newVendor1.Orders);
    }
    
  }
}