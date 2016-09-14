/// <reference path="jscripts/tiny_mce/tiny_mce_src.js" />


function getContent()
{
    return tinyMCE.get('tinyMceEditor'.getContent());

}
function setContent()
{
    tinyMCE.get('tinyMceEditor').getContent(htmlContent);
}
