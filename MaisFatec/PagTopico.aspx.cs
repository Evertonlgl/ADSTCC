using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using AjaxControlToolkit;




public partial class PagTopico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {

                Usuario pes = (Usuario)Session["Usuario"];

                
            }
        }

        //Response.Write(Session["NOME"].ToString());
        //Response.Write(Session["EMAIL"].ToString());


        //Session.Abbandon; desativa sessão
        //limpando a sessão
        //Session.clear();

        //Session.RemoveAll(); Apaga as informações da sessão
        //Session.Timeout(30); limita em 30 minutos

        if (!Page.IsPostBack)
        {
            if (tnyConteudo != null && !string.IsNullOrWhiteSpace(tnyConteudo.Value))
            {
                tnyConteudo.Value = HttpUtility.HtmlDecode(tnyConteudo.Value);
            }
        }



    }


    protected void Salvar_Click(object sender, EventArgs e)
    {
        Response.Redirect("pagHome.aspx");
    }
    protected void btnInserir_Click(object sender, EventArgs e)
    {
        Usuario usu = (Usuario)Session["Usuario"];
        if (usu.Permissoes.ForumPostagem == true)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text.ToString()) | string.IsNullOrEmpty(txtPalavraChave.Text.ToString()) | string.IsNullOrEmpty(Texts.ToString()) | string.IsNullOrWhiteSpace(txtTitulo.Text.ToString()) | string.IsNullOrWhiteSpace(txtPalavraChave.Text.ToString()) | string.IsNullOrWhiteSpace(Texts.ToString()) | string.IsNullOrWhiteSpace(tnyConteudo.Value) | string.IsNullOrEmpty(tnyConteudo.Value))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Por Favor preencher todos os campos')", true);

            }
            else
            {

                Topico top = new Topico();

                top.Codigo = usu.PerfilC.IdPerfil;
                top.Titulo = (txtTitulo.Text);
                top.PalavraChave = (txtPalavraChave.Text);
                top.Conteudo = (Texts.ToString());
                top.DataTopico = (DateTime.Now);
                String UploadedFile1 = fupAnexo.PostedFile.FileName;
                int ExtractPos = UploadedFile1.LastIndexOf("\\") + 1;
                
                String UploadedFileName1 = UploadedFile1.Substring(ExtractPos, UploadedFile1.Length - ExtractPos);
                top.Anexo = UploadedFileName1;

                if (TopicoDB.NovoTopico(top) == -2)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Topico não Inserido')", true);
                }
                else
                {
                    if (fupAnexo.HasFile)
                    {
                        // Before attempting to save the file, verify
                        // that the FileUpload control contains a file.
                        string extensao = fupAnexo.FileName.Substring(fupAnexo.FileName.Length - 5).ToLower();

                        if (extensao == ".docx" | extensao == ".docm" | extensao == ".dotx" | extensao == ".dotm"
                           | extensao == ".xlsx" | extensao == ".xlsm" | extensao == ".xltx" | extensao == ".xltm" | extensao == ".xlsb" | extensao == ".xlam"
                           | extensao == ".pptx" | extensao == ".pptm" | extensao == ".potx" | extensao == ".potm" | extensao == ".ppam" | extensao == ".ppsx" | extensao == ".ppsm" | extensao == ".sldx" | extensao == ".sldm" | extensao == ".thmx")
                        {
                            if (fupAnexo.HasFile)


                                // Call a helper method routine to save the file.
                                SalvaOffice(fupAnexo.PostedFile);

                            else
                                // Notify the user that a file was not uploaded.

                                lblMsg.Text = "You did not specify a file to upload.";

                        }
                        else
                        {
                            extensao = fupAnexo.FileName.Substring(fupAnexo.FileName.Length - 4).ToLower();


                            if (extensao != ".jpg" && extensao != ".gif" && extensao != ".png")
                            {
                                lblMsg.Text = "Tipo de Arquivo Invalido";
                                if (TopicoDB.ExcluirUltimoTopico() == -2)
                                {

                                    lblMsg.Text = "Erro na exclussão";
                                }
                            }
                            else
                            {
                                SalvarFoto("teste");
                            }
                        }

                    }
                    txtTitulo.Text = "";
                    txtPalavraChave.Text = "";
                    tnyConteudo.Value = "";
                }

            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Usuario Bloqueado, Aguardar o Tempo de Bloqueio')", true);
        }
    }
    public string Texts
    {
        get
        {
            return HttpUtility.HtmlDecode(tnyConteudo.Value);
        }
        set
        {
            tnyConteudo.Value = value;
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {


        List<string> CompletionSet = new List<string>();
        CompletionSet = TopicoDB.PesquisaTopico();



        return (from m in CompletionSet where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();

    }
    //protected void btnEnviar_Click(object sender, EventArgs e)
    //{
    //    Subir("Teste");
    //}


    protected void Salvar_Click1(object sender, EventArgs e)
    {





    }



    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        FuncoesBasicas.Funcoes.Busca(txtBusca.Text);
    }


    public bool SalvarFoto(string nomeImagem)
    {
        if (fupAnexo.FileName == "")
        {
            lblMsg.Text = "Selecione uma imagem antes de clicar em enviar!";
            return false;
        }
        else
        {
            string extensao = fupAnexo.FileName.Substring(fupAnexo.FileName.Length - 4).ToLower();

            if (extensao != ".jpg" && extensao != ".gif" && extensao != ".png")
            {
                lblMsg.Text = "Arquivo inválido, por favor selecione somente arquivos do tipo JPG, GIF ou PNG!";
                TopicoDB.ExcluirUltimoTopico();
                return false;
            }
            else
            {

                String UploadedFile = fupAnexo.PostedFile.FileName;
                int ExtractPos = UploadedFile.LastIndexOf("\\") + 1;
                
                String UploadedFileName = UploadedFile.Substring(ExtractPos, UploadedFile.Length - ExtractPos);


                fupAnexo.PostedFile.SaveAs(Request.PhysicalApplicationPath + "Anexo\\AnexoImagem\\" + UploadedFileName);



                //thumbnail creation starts

                try
                {
                    //Read in the image filename whose thumbnail has to be created

                    String imageUrl = UploadedFileName;

                    if (imageUrl.IndexOf("/") >= 0 || imageUrl.IndexOf("\\") >= 0)
                    {
                        //We found a / or \
                        Response.End();
                    }

                    //the uploaded image will be stored in the Pics folder.
                    //to get resize the image, the original image has to be accessed from the
                    //Pics folder
                    imageUrl = "Anexo/AnexoImagem/" + imageUrl;

                    System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imageUrl));

                    System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                    System.Drawing.Image thumbNailImg;

                    int width;
                    int height;
                    ///Verifica se o width em px da imagem é maior que 200
                    if (fullSizeImg.Size.Width > 200)
                    {
                        //Aqui é feita a renderização proporcional da altura da imagem
                        //tomando por base que o largura final dela é de 50px;
                        width = 64;
                        height = (int)(width * fullSizeImg.Height) / fullSizeImg.Width;
                    }
                    else
                    {
                        width = fullSizeImg.Size.Width;
                        height = fullSizeImg.Size.Height;
                    }


                    thumbNailImg = fullSizeImg.GetThumbnailImage(width, height, dummyCallBack, IntPtr.Zero);

                    //We need to create a unique filename for each generated image
                    String MyString = "P_" + UploadedFileName ;

                    //Save the thumbnail in Png format. You may change it to a diff format with the ImageFormat property
                    thumbNailImg.Save(Request.PhysicalApplicationPath + "Anexo\\AnexoImagem\\" + MyString, System.Drawing.Imaging.ImageFormat.Jpeg);
                    thumbNailImg.Dispose();
                    fullSizeImg.Dispose();
                    //Display the original & the newly generated thumbnail
                    // File.Delete(MapPath("Anexo/AnexoImagem/" + UploadedFileName));
                    return true;

                }

                catch (Exception ex)
                {
                    lblMsg.Text = "Erro: " + ex.ToString();
                    return false;
                }
            }
        }

    }
    public bool ThumbnailCallback()
    {
        return false;
    }
    void SalvaOffice(HttpPostedFile file)
    {
        int iFileSize = file.ContentLength;

        if (iFileSize < 2000000)  // 2MB approx (actually less though)
        {

            // Specify the path to save the uploaded file to.
            string savePath = Request.PhysicalApplicationPath + "Anexo\\AnexoArquivo\\";

            // Get the name of the file to upload.
            string fileName = fupAnexo.FileName;

            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            // Check to see if a file already exists with the
            // same name as the file to upload.        
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;

                // Notify the user that the file name was changed.
                lblMsg.Text = "A file with the same name already exists." +
                    "<br />Your file was saved as " + fileName;
            }
            else
            {
                // Notify the user that the file was saved successfully.
                lblMsg.Text = "Anexado com sucesso.";
            }

            // Append the name of the file to upload to the path.
            savePath += fileName;

            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            fupAnexo.SaveAs(savePath);

        }
        else
        {
            lblMsg.Text = "Arquivo Muito Pessado.";
        }

    }
    private void CreateButton()
    {
        Button bt = new Button();

        bt.Text = "Calcular";

        bt.Click += new EventHandler(Salvar_Click);

        divButton.Controls.Add(bt);
    }
    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        //txtTitulo.ToString() = new string();
    }
   
    protected void File_Upload_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
    {
        var ajaxUpload = (AjaxFileUpload)sender;
        string strLongFilePath = e.FileName;
        string strFileExtension = System.IO.Path.GetExtension(strLongFilePath);
        char[] ch = new char[] { '\\' };
        string[] strPath = strLongFilePath.Split(ch);
        string strInternalFileName = DateTime.Now.ToFileTime().ToString() + strFileExtension;
        string strDestPath = Server.MapPath("~/Anexo/AnexoImagem/");
        ajaxUpload.SaveAs(@strDestPath + strInternalFileName);
        //Save path,

    }
   
}