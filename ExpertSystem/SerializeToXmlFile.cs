using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ExpertSystem
{
    class SerializeToXmlFile
    {
        #region "Field"

        private string fileName;
        #endregion

        #region "Constructor"

        public SerializeToXmlFile(string fileName)
        {
            this.fileName = fileName;
        }
        #endregion

        #region "Serialize knowledge base"

        public void SerializeKnowledgeBase(KnowledgeBase KB)
        {
            XmlWriter writer = null;
            XmlSerializer xser = new XmlSerializer(typeof(KnowledgeBase));

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true,
                    Encoding = Encoding.UTF8,
                    OmitXmlDeclaration = false
                };
                writer = XmlWriter.Create(fileName, settings);

                /* Serialize object */
                xser.Serialize(writer, KB, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyjątek: {0}", ex.Message);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        } 
        #endregion
    }
}
