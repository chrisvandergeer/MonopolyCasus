<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
<body>
  <h2>Monopoly</h2>
  <table border="0">
    <tr bgcolor="#9acd32">
      <th>Ronde</th>
      <th>Spelresultaten</th>
    </tr>
    <xsl:for-each select="monopolyspel/ronde">
    <tr>
    <td valign="top"><xsl:value-of select="@nr"/></td>
    <table border="1"><tr bgcolor="#0acd32"><th width="10%">speler</th><th width="90%">Acties</th></tr>
    <xsl:for-each select="beurt">
	<tr>
		<td valign="top"><xsl:value-of select="@speler"/></td>
		<td><table border="0"><xsl:for-each select="gebeurtenis"><tr>
						<td><xsl:value-of select="."/></td>
		</tr>
	        </xsl:for-each></table></td>
	</tr>
    </xsl:for-each>
    </table>
    <H3>Ronde tussenstand</H3>
    <table border="1"><tr bgcolor="#9a0d32"><th>speler</th><th>Geld</th><th>straten</th><th>hypotheken</th><th>Huizen</th></tr>
	    <xsl:for-each select="stand/speler">
	<tr>
		<td><xsl:value-of select="@naam"/></td>
		<td><xsl:value-of select="kasgeld"/></td>
		<td><xsl:value-of select="straten"/></td>
		<td><xsl:value-of select="hypotheken"/></td>
		<td><xsl:value-of select="huizen"/></td>
	</tr>
    </xsl:for-each>
    </table>
    </tr>
    </xsl:for-each>
  </table>
  </body>
    </html>
</xsl:template>    
</xsl:stylesheet>
