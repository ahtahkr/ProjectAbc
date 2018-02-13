﻿using AustinsFirstProject.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AustinsFirstProject.StockProcessor.IEXTrading
{
    public class Chart
    {
        public List<Previous> Previous { get; set; }
        public string Symbol { get; set; }
        public bool Api_Called { get; set; } = false;

        public Chart()
        {
            this.Previous = new List<Previous>();
        }

        public bool Call_Api(string symbol, string index = "")
        {
            this.Symbol = symbol;
            try
            {
                this.Previous = JsonConvert.DeserializeObject<List<Previous>>(
                                Utility.HttpRequestor.Chart(symbol, index));

                this.Api_Called = true;
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log_Error(symbol + " : " + ex.Message, "Call_Api");
                Logger.Log_Error("AustinsFirstProject.StockProcessor.IEXTrading.Chart.Call_Api(" + symbol + ") failed. Error Msg: " + ex.Message);
                return false;
            }
        }

        public void Save_to_File(string directory = "")
        {
            try
            {
                FileFormats fileFormats = new FileFormats();
                FileFormat fileFormat = new FileFormat();

                for (int a = 0; a < this.Previous.Count; a++)
                {
                    fileFormat = JsonConvert.DeserializeObject<FileFormat>(
                                    JsonConvert.SerializeObject(this.Previous[a]));
                    fileFormat.Symbol = this.Symbol;
                    fileFormats.FileFormat.Add(fileFormat);
                    fileFormats.Save_to_File(directory);
                    fileFormats.FileFormat = new List<FileFormat>();
                }

                
            }
            catch (Exception ex)
            {
                Logger.Log_Error("AustinsFirstProject.StockProcessor.IEXTrading.Chart.Save_to_File(" + directory + ") failed. Error Msg: " + ex.Message);
            }
        }
    }
}
