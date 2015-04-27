/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pl.www.matrixdisplay;

import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.Graphics;

/**
 *
 * @author Patryk
 */
public class MatrixDisplay extends Component {
    
    private Color dotEnabledColor;
    private Color dotDisabledColor;
    private int dotRadius;
    private String matrixText = "E";
    
    public MatrixDisplay()
    {
        setDotDisabledColor(Color.GRAY);
        setDotEnabledColor(Color.ORANGE);
        setSize(300,48);
        setPreferredSize(new Dimension(300,48));
        setDotRadius(16);
    }
    
    @Override
    public synchronized void paint(Graphics g) {
        int dotsOnWidth = getMatrixText().length() * 7;
        int dotsOnHeight = 7;
        
        g.setColor(dotDisabledColor);
        for(int i=0;i<dotsOnWidth;++i) {
            byte charIndex = charToIndex(matrixText.charAt(i/7));
            //System.out.println("char: " + matrixText.charAt(i/7) + " index: " + charIndex);
            for(int j=0;j<dotsOnHeight; ++j) {
                int x = i * (dotRadius * 2) + dotRadius * 2;
                int y = j * (dotRadius * 2) + dotRadius * 2;
                
                if(charIndex < 127) {
                    if(Letters.SLetters[charIndex][j][i%7] == 0)
                        g.setColor(dotDisabledColor);
                    else if(Letters.SLetters[charIndex][j][i%7] == 1)
                        g.setColor(dotEnabledColor);
                } else {
                    
                }
                
                g.fillOval(x, y, dotRadius*2, dotRadius*2);
            }
        }
    }
    
    /**
     * @return the dotEnabledColor
     */
    public Color getDotEnabledColor() {
        return dotEnabledColor;
    }

    /**
     * @param dotEnabledColor the dotEnabledColor to set
     */
    public void setDotEnabledColor(Color dotEnabledColor) {
        firePropertyChange("dotEnabledColor", this.dotEnabledColor, dotEnabledColor);
        this.dotEnabledColor = dotEnabledColor;
    }

    /**
     * @return the dotDisabledColor
     */
    public Color getDotDisabledColor() {
        return dotDisabledColor;
    }

    /**
     * @param dotDisabledColor the dotDisabledColor to set
     */
    public void setDotDisabledColor(Color dotDisabledColor) {
        firePropertyChange("dotDisabledColor", this.dotDisabledColor, dotDisabledColor);
        this.dotDisabledColor = dotDisabledColor;
    }

    /**
     * @return the dotRadius
     */
    public int getDotRadius() {
        return dotRadius;
    }

    /**
     * @param dotRadius the dotRadius to set
     */
    public void setDotRadius(int dotRadius) {
        if(dotRadius <= 0) {
            firePropertyChange("dotRadius", this.dotRadius, 1);
            this.dotRadius = 1;
        }
        else {
            firePropertyChange("dotRadius", this.dotRadius, dotRadius);
            this.dotRadius = dotRadius;
        }
    }

    /**
     * @return the matrixText
     */
    public String getMatrixText() {
        return matrixText;
    }

    /**
     * @param matrixText the matrixText to set
     */
    public void setMatrixText(String matrixText) {
        firePropertyChange("matrixText", this.matrixText, matrixText);
        this.matrixText = matrixText;
    }
    
    /**
     * Returns the <b>Letters.SLetters</b> char index
     * @param _c char to get index
     * @return char index if it's in supported range, if not - 0
     */
    private byte charToIndex(char _c)
    {
        byte code = (byte) _c;
        
        //System.out.println("char: " + _c + " code: " + code);
        
        //Capital letter
        if (code >= 65 && code <= 90)
            return (byte) (code - 65);
        //Small letter
        else if (code >= 97 && code <= 122)
            return (byte) (code - 97);
        //Numbers 0-9
        else if (code >= 48 && code <= 57)
            return (byte) (code - 22);
        //SPACE
        else if (code == 32)
            return (byte) 127;

        return 0;
    }
}
