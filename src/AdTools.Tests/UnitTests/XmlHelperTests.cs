using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using AdTools.Library.Common;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Common.Logging;
using Common.Logging.Simple;
using NUnit.Framework;
using AdTools.Library.Infrastructure;

namespace AdTools.Tests.UnitTests
{
    [TestFixture(Category = "UnitTests")]
    public class XmlHelperTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void XmlHelperGetNodeValue1()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                var target = testBooStrapper.Container.Resolve<IXmlHelper>();
                var testXml = GetTestXml();
                var nodeValue = target.GetNodeValue(testXml.Item1, "empty:GPO/empty:ReadTime", testXml.Item2);
                Assert.IsNotNullOrEmpty(nodeValue, "ReadTime was not found");
            }
        }

        [Test]
        public void XmlHelperRemoveNodeTest1()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                var target = testBooStrapper.Container.Resolve<IXmlHelper>();
                var testXml = GetTestXml();
                var nodeValue = target.GetNodeValue(testXml.Item1, "/empty:GPO/empty:ReadTime", testXml.Item2);
                Assert.IsNotNullOrEmpty(nodeValue, "ReadTime was not found");
                var modifiedXml = target.RemoveNode(testXml.Item1, "/empty:GPO/empty:ReadTime", testXml.Item2);
                nodeValue = target.GetNodeValue(modifiedXml, "/empty:GPO/empty:ReadTime", testXml.Item2);
                Assert.IsNullOrEmpty(nodeValue, "ReadTime was not removed");
            }
        }

        private Tuple<string, Dictionary<string,string>> GetTestXml()
        {
            var xml = @"<?xml version=""1.0"" encoding=""utf-16""?>
<GPO xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://www.microsoft.com/GroupPolicy/Settings"">
  <Identifier>
    <Identifier xmlns=""http://www.microsoft.com/GroupPolicy/Types"">{0C2EFC6B-67F0-40E0-B64B-2A4D125575E1}</Identifier>
    <Domain xmlns=""http://www.microsoft.com/GroupPolicy/Types"">deta410.local</Domain>
  </Identifier>
  <Name>SKALA DNS 2012 Server Policy 1.0.0</Name>
  <IncludeComments>true</IncludeComments>
  <CreatedTime>2014-04-08T08:54:40</CreatedTime>
  <ModifiedTime>2014-04-08T08:54:41</ModifiedTime>
  <ReadTime>2015-11-01T16:53:22.7372451Z</ReadTime>
  <SecurityDescriptor>
    <SDDL xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">O:DAG:DAD:PAI(OA;CI;CR;edacfd8f-ffb3-11d1-b41d-00a0c968f939;;AU)(A;;CCDCLCSWRPWPDTLOSDRCWDWO;;;DA)(A;CI;CCDCLCSWRPWPDTLOSDRCWDWO;;;DA)(A;CI;CCDCLCSWRPWPDTLOSDRCWDWO;;;S-1-5-21-2762072435-4076762049-1369760685-519)(A;CI;LCRPLORC;;;ED)(A;CI;LCRPLORC;;;AU)(A;CI;CCDCLCSWRPWPDTLOSDRCWDWO;;;SY)(A;CIIO;CCDCLCSWRPWPDTLOSDRCWDWO;;;CO)</SDDL>
    <Owner xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">
      <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-21-2762072435-4076762049-1369760685-512</SID>
      <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">deta410\Domain Admins</Name>
    </Owner>
    <Group xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">
      <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-21-2762072435-4076762049-1369760685-512</SID>
      <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">deta410\Domain Admins</Name>
    </Group>
    <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">true</PermissionsPresent>
    <Permissions xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">
      <InheritsFromParent>false</InheritsFromParent>
      <TrusteePermissions>
        <Trustee>
          <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-9</SID>
          <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">NT AUTHORITY\ENTERPRISE DOMAIN CONTROLLERS</Name>
        </Trustee>
        <Type xsi:type=""PermissionType"">
          <PermissionType>Allow</PermissionType>
        </Type>
        <Inherited>false</Inherited>
        <Applicability>
          <ToSelf>true</ToSelf>
          <ToDescendantObjects>false</ToDescendantObjects>
          <ToDescendantContainers>true</ToDescendantContainers>
          <ToDirectDescendantsOnly>false</ToDirectDescendantsOnly>
        </Applicability>
        <Standard>
          <GPOGroupedAccessEnum>Read</GPOGroupedAccessEnum>
        </Standard>
        <AccessMask>0</AccessMask>
      </TrusteePermissions>
      <TrusteePermissions>
        <Trustee>
          <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-21-2762072435-4076762049-1369760685-519</SID>
          <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">deta410\Enterprise Admins</Name>
        </Trustee>
        <Type xsi:type=""PermissionType"">
          <PermissionType>Allow</PermissionType>
        </Type>
        <Inherited>false</Inherited>
        <Applicability>
          <ToSelf>true</ToSelf>
          <ToDescendantObjects>false</ToDescendantObjects>
          <ToDescendantContainers>true</ToDescendantContainers>
          <ToDirectDescendantsOnly>false</ToDirectDescendantsOnly>
        </Applicability>
        <Standard>
          <GPOGroupedAccessEnum>Edit, delete, modify security</GPOGroupedAccessEnum>
        </Standard>
        <AccessMask>0</AccessMask>
      </TrusteePermissions>
      <TrusteePermissions>
        <Trustee>
          <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-21-2762072435-4076762049-1369760685-512</SID>
          <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">deta410\Domain Admins</Name>
        </Trustee>
        <Type xsi:type=""PermissionType"">
          <PermissionType>Allow</PermissionType>
        </Type>
        <Inherited>false</Inherited>
        <Applicability>
          <ToSelf>true</ToSelf>
          <ToDescendantObjects>false</ToDescendantObjects>
          <ToDescendantContainers>true</ToDescendantContainers>
          <ToDirectDescendantsOnly>false</ToDirectDescendantsOnly>
        </Applicability>
        <Standard>
          <GPOGroupedAccessEnum>Edit, delete, modify security</GPOGroupedAccessEnum>
        </Standard>
        <AccessMask>0</AccessMask>
      </TrusteePermissions>
      <TrusteePermissions>
        <Trustee>
          <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-11</SID>
          <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">NT AUTHORITY\Authenticated Users</Name>
        </Trustee>
        <Type xsi:type=""PermissionType"">
          <PermissionType>Allow</PermissionType>
        </Type>
        <Inherited>false</Inherited>
        <Applicability>
          <ToSelf>true</ToSelf>
          <ToDescendantObjects>false</ToDescendantObjects>
          <ToDescendantContainers>true</ToDescendantContainers>
          <ToDirectDescendantsOnly>false</ToDirectDescendantsOnly>
        </Applicability>
        <Standard>
          <GPOGroupedAccessEnum>Apply Group Policy</GPOGroupedAccessEnum>
        </Standard>
        <AccessMask>0</AccessMask>
      </TrusteePermissions>
      <TrusteePermissions>
        <Trustee>
          <SID xmlns=""http://www.microsoft.com/GroupPolicy/Types"">S-1-5-18</SID>
          <Name xmlns=""http://www.microsoft.com/GroupPolicy/Types"">NT AUTHORITY\SYSTEM</Name>
        </Trustee>
        <Type xsi:type=""PermissionType"">
          <PermissionType>Allow</PermissionType>
        </Type>
        <Inherited>false</Inherited>
        <Applicability>
          <ToSelf>true</ToSelf>
          <ToDescendantObjects>false</ToDescendantObjects>
          <ToDescendantContainers>true</ToDescendantContainers>
          <ToDirectDescendantsOnly>false</ToDirectDescendantsOnly>
        </Applicability>
        <Standard>
          <GPOGroupedAccessEnum>Edit, delete, modify security</GPOGroupedAccessEnum>
        </Standard>
        <AccessMask>0</AccessMask>
      </TrusteePermissions>
    </Permissions>
    <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
  </SecurityDescriptor>
  <FilterDataAvailable>true</FilterDataAvailable>
  <Computer>
    <VersionDirectory>1</VersionDirectory>
    <VersionSysvol>1</VersionSysvol>
    <Enabled>true</Enabled>
    <ExtensionData>
      <Extension xmlns:q1=""http://www.microsoft.com/GroupPolicy/Settings/Security"" xsi:type=""q1:SecuritySettings"">
        <q1:SystemServices>
          <q1:Name>svsvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>KtmRm</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vmicvss</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>AppIDSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>PlugPlay</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>wercplsupport</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>LanmanWorkstation</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>MpsSvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>hkmsvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>BFE</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>ProfSvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DPS</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>VSS</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DcomLaunch</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>BITS</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DsmSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Appinfo</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>EapHost</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>MSiSCSI</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>pla</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RpcSs</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WinRM</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WdiSystemHost</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>PolicyAgent</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WdiServiceHost</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>gpsvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>KeyIso</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>NcaSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>defragsvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RPCEptMapper</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>UI0Detect</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vmictimesync</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>TermService</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>MMCSS</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Netlogon</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DNS</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>BrokerInfrastructure</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RasAuto</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SSDPSRV</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SENS</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>ShellHWDetection</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SamSs</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SNMPTRAP</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Winmgmt</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Schedule</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SharedAccess</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Dnscache</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>PrintNotify</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DHCP</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>seclogon</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>iphlpsvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>wmiApSrv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>fdPHost</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>LanmanServer</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>ALG</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>AudioEndpointBuilder</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WcsPlugInService</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WinHttpAutoProxySvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>ComSysApp</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>upnphost</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DeviceAssociationService</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>sppsvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SCardSvr</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>KPSSVC</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>hidserv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vmickvpexchange</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>VaultSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RemoteRegistry</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>eventlog</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Netman</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>nsi</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>sacsvr</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Browser</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>wuauserv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>wudfsvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SstpSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vmicheartbeat</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SCPolicySvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Power</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>FDResPub</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WerSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>AudioSrv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vmicrdv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vds</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WSService</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>lmhosts</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>THREADORDER</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>vmicshutdown</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SessionEnv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RpcLocator</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RemoteAccess</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>TrkWks</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>CertPropSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>msiserver</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>WPDBusEnum</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>MSDTC</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>UmRdpService</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>LSM</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RasMan</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>netprofm</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>AeLookupSvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Wecsvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>DeviceInstall</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>dot3svc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Spooler</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>UALSVC</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>nettcpportsharing</q1:Name>
          <q1:StartupMode>Disabled</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>RSoPProv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>AppMgmt</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>AllUserInstallAgent</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>swprv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>W32Time</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>PerfHost</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>TapiSrv</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>napagent</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>IKEEXT</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>SysMain</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>FontCache</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>Themes</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>NlaSvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>EFS</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>CryptSvc</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>EventSystem</q1:Name>
          <q1:StartupMode>Automatic</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
        <q1:SystemServices>
          <q1:Name>lltdsvc</q1:Name>
          <q1:StartupMode>Manual</q1:StartupMode>
          <q1:SecurityDescriptor>
            <PermissionsPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</PermissionsPresent>
            <AuditingPresent xmlns=""http://www.microsoft.com/GroupPolicy/Types/Security"">false</AuditingPresent>
          </q1:SecurityDescriptor>
        </q1:SystemServices>
      </Extension>
      <Name>Security</Name>
    </ExtensionData>
  </Computer>
  <User>
    <VersionDirectory>1</VersionDirectory>
    <VersionSysvol>1</VersionSysvol>
    <Enabled>false</Enabled>
  </User>
  <LinksTo>
    <SOMName>Domain Controllers</SOMName>
    <SOMPath>deta410.local/Domain Controllers</SOMPath>
    <Enabled>true</Enabled>
    <NoOverride>false</NoOverride>
  </LinksTo>
</GPO>";
            var nameSpaces = new Dictionary<string, string>
            {
                {"http://www.w3.org/2001/XMLSchema-instance", "xsi"},
                {"http://www.w3.org/2001/XMLSchema", "xsd"},
                {"http://www.microsoft.com/GroupPolicy/Settings", "empty"}
            };
            return new Tuple<string, Dictionary<string,string>>(xml, nameSpaces );
        }

        internal class TestBootStrapper : IDisposable
        {
            private readonly ILog _logger;
            private IWindsorContainer _container;

            public TestBootStrapper(Type type)
            {
                _logger = new ConsoleOutLogger(type.Name, LogLevel.All, true, false, false, "yyyy-MM-dd HH:mm:ss");
            }

            public IWindsorContainer Container
            {
                get
                {
                    if (_container == null)
                    {
                        _container = new WindsorContainer();
                        _container.Register(Component.For<IWindsorContainer>().Instance(_container));

                        //Configure logging
                        _container.Register(Component.For<ILog>().Instance(_logger));

                        //Manual override registrations for interfaces that the interface under test is dependent on
                        //_container.Register(Component.For<ISomeInterface>().Instance(MockRepository.GenerateStub<ISomeInterface>()));

                        //Factory registrations example:

                        //container.Register(Component.For<ITeamProviderFactory>().AsFactory());
                        //container.Register(
                        //    Component.For<ITeamProvider>()
                        //        .ImplementedBy<CsvTeamProvider>()
                        //        .Named("CsvTeamProvider")
                        //        .LifeStyle.Transient);
                        //container.Register(
                        //    Component.For<ITeamProvider>()
                        //        .ImplementedBy<SqlTeamProvider>()
                        //        .Named("SqlTeamProvider")
                        //        .LifeStyle.Transient);

                        ///////////////////////////////////////////////////////////////////
                        //Automatic registrations
                        ///////////////////////////////////////////////////////////////////
                        //
                        //   Register all command providers and attach logging interceptor
                        //
                        const string libraryRootNameSpace = "AdTools.Library";

                        //
                        //   Register all singletons found in the library
                        //
                        _container.Register(Classes.FromAssemblyContaining<CommandDefinition>()
                            .InNamespace(libraryRootNameSpace, true)
                            .If(type => Attribute.IsDefined(type, typeof(SingletonAttribute)))
                            .WithService.DefaultInterfaces().LifestyleSingleton());

                        //
                        //   Register all transients found in the library
                        //
                        _container.Register(Classes.FromAssemblyContaining<CommandDefinition>()
                            .InNamespace(libraryRootNameSpace, true)
                            .WithService.DefaultInterfaces().LifestyleTransient());

                    }
                    return _container;
                }

            }

            ~TestBootStrapper()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_container != null)
                    {
                        _container.Dispose();
                        _container = null;
                    }
                }
            }
        }
    }
}