<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
     <head><title>Students</title></head>
  <body>
  <h1>Students</h1>
    <ul>
	<xsl:for-each select="students/student">
    <li>
      <p>
      <strong>
        <xsl:value-of select="name"/>
      </strong>
      <br/>Birthdate: <i>
        <xsl:value-of select="birthDate"/>
      </i>
      <br/>Sex: <i>
        <xsl:value-of select="sex"/>
      </i>
      <br/>Email: <i>
        <xsl:value-of select="email"/>
      </i>
      <br/>Phone: <i>
        <xsl:value-of select="phone"/>
      </i>
      <br/>Specialty: <i>
        <xsl:value-of select="speciality"/>
      </i>
      <table>
        <thead>
          <th>Name</th>
          <th>Score</th>
          <th>Tutor</th>
        </thead>

        <xsl:for-each select="takenExams/exam">
          <tbody>
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="score"/>
              </td>
              <td>
                <xsl:value-of select="tutor"/>
              </td>
            </tr>
          </tbody>
        </xsl:for-each>
      </table>
      </p>
    </li>
	</xsl:for-each>
    </ul>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>