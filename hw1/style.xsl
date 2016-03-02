<?xml version="1.0" encoding="UTF-8"?>
<html xsl:version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <body style="font-family:Arial;font-size:12pt;background-color:#EEEEEE">
    <h1>Recommended Podcasts</h1>
    <xsl:for-each select="podcasts/podcast">
      <xsl:variable name="link">
        <xsl:value-of select="url"/>
      </xsl:variable>
      <div>
        <h2>
          <a href="{$link}">
            <xsl:value-of select="name"/>
          </a>
        </h2>
        <hr/>
        <h3>Genre: <xsl:value-of select="genre"/></h3>
        <p><xsl:value-of select="about"/></p>
        <hr/>
      </div>
    </xsl:for-each>
  </body>
</html>