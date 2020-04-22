using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.OracleClient;
using System.Data;
using Oracle.DataAccess.Client;

namespace PIEBox
{
    public class SQLHelper
    {
        public static OracleConnection creatConnection() {
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-QPITIGJ)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User ID=scott;Password=Dang931102");
            //那个 192.168.1.210  是 Oracle  数据库服务器的 IP 地址 1521  是 默认的端口号 SERVICE_NAME=ORCL  意思是 那个 Oracle 数据库服务是 ORCL 后面就是 用户名 密码了。
            return conn;
        }
        public static DataTable select(String sql)
        {
            //conn.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=***.***.***.***)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=***)));Persist Security Info=True;User ID=***;Password=***;";
            String connString = "Data Source=ORCL;User ID=scott;PassWord=Dang931102";
           // OracleConnection conn = new OracleConnection(@"Data Source=DESCRIPTION=(CONNECT_DATA=(SERVICE_NAME=))(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-QPITIGJ)(PORT=1521)));User ID=scott;Password=Dang931102");
            OracleConnection conn = new OracleConnection(connString);
            conn.Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            conn.Close();
            cmd.Dispose();
            return dt;
        }

        //下面这个函数的意思就是delete from table where atribute = value;
        //这里的tble、attribute和value是三个参数，自己看着输吧，注意这个value是字符串，在数据库里是varchar类型，如果删除int的话，自己改一下代码就好了！
        //算了，我自己改：1.把最后一个String value的String 改成int value
        //                2.把函数第三行的['" + value + "'"]改成[" + value]就欧克啦
        public static int delete(String table, String attribute, String value)
        {
            try
            {
                OracleConnection conn = new OracleConnection(@"Data Source=orcl;User ID=system;Password=a123456A");
                conn.Open();
                String sql = "delete from " + table + " where " + attribute + " ='" + value + "'";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                conn.Close();
                cmd.Dispose();
                return 0;//返回0就是删除成功！
            }
            catch (Exception ex)
            {
                //返回1就是删除失败！
                return 1;
            }

        }
        //下面这个函数的意思就是update table set atribute_alter = new_value where atribute = value;
        //有点复杂哈，但是这样功能才齐全嘛。
        //具体的不多说啦，主要是修改varchar类型的，所以多用varchar,改成int参照delete函数好了。（其实可以写两个，一个改varchar,一个改int我赶脚数据库里这两种类型够用了
        public static int update(String table, String attribute_alter, String new_value, String attribute, String value)
        {
            try
            {
                OracleConnection conn = new OracleConnection(@"Data Source=orcl;User ID=system;Password=a123456A");
                conn.Open();
                String sql = "update " + table + " set " + attribute_alter + " ='" + new_value + "'where " + attribute + " = '" + value + "'";
                OracleCommand cmd = new OracleCommand(sql, conn);
                OracleDataAdapter oda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                conn.Close();
                cmd.Dispose();
                return 0;//返回0就是修改成功！
            }
            catch (Exception ex)
            {
                //返回1就是修改失败！
                return 1;
            }
        }
        //由于插入比较复杂涉及到多个值甚至多个不同类型的值，这里写了改两列数据的，需要用时在这里修改
        //其实更建议直接用上面的select()因为这个小括号里可以直接输入语句，自然也可输入insert语句了比较灵活
        public static int insert(String table, String[] attributes, String[] values)
        {
            OracleConnection conn = new OracleConnection(@"Data Source=orcl;User ID=system;Password=a123456A");
            conn.Open();
            String sql = "insert into " + table + " （" + attributes[0] + "," + attributes[1] + ") values(" + values[0] + "," + values[1] + ")";
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            conn.Close();
            cmd.Dispose();
            return 0;
        }
        //为了灵活起见下面直接给一个输入语句的通用方法
        public static int sql(String sql)
        {
            OracleConnection conn = new OracleConnection(@"Data Source=orcl;User ID=system;Password=a123456A");
            conn.Open();
            OracleCommand cmd = new OracleCommand(sql, conn);
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            conn.Close();
            cmd.Dispose();
            return 0;
        }
    }
}
