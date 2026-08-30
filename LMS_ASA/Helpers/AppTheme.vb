Imports System.Drawing

''' <summary>
''' Centralized theme colors for the LMS application based on ASA Philippines brand colors.
''' Primary Red-Orange: #E73F1E (rgb 231, 63, 30)
''' Secondary Vibrant Orange: #FB6C00 (rgb 251, 108, 0)
''' Accent Amber/Gold: #F9B637 (rgb 249, 182, 55)
''' Soft Cream/Pastel: #FFDD9C (rgb 255, 221, 156)
''' </summary>
Public Module AppTheme

    ' ── Core Brand Palette ──────────────────────────────────────
    Public ReadOnly Primary As Color = Color.FromArgb(231, 63, 30)          ' #E73F1E - Primary Red-Orange
    Public ReadOnly PrimaryDark As Color = Color.FromArgb(184, 46, 18)      ' #B82E12 - Darker Shade for Headers/Footers
    Public ReadOnly Secondary As Color = Color.FromArgb(251, 108, 0)        ' #FB6C00 - Vibrant Orange / Hover
    Public ReadOnly AccentAmber As Color = Color.FromArgb(249, 182, 55)      ' #F9B637 - Warm Amber / Highlights
    Public ReadOnly LightCream As Color = Color.FromArgb(255, 221, 156)      ' #FFDD9C - Soft Cream / Subtitles on dark

    ' ── UI Component Tints ──────────────────────────────────────
    Public ReadOnly SidebarBg As Color = Color.FromArgb(231, 63, 30)         ' #E73F1E
    Public ReadOnly SidebarHeaderBg As Color = Color.FromArgb(184, 46, 18)   ' #B82E12
    Public ReadOnly SidebarFooterBg As Color = Color.FromArgb(184, 46, 18)   ' #B82E12
    Public ReadOnly SidebarDivider As Color = Color.FromArgb(249, 182, 55)    ' #F9B637
    Public ReadOnly SidebarBtnHover As Color = Color.FromArgb(251, 108, 0)   ' #FB6C00
    Public ReadOnly SidebarText As Color = Color.FromArgb(255, 245, 235)      ' Soft Off-White / Cream
    Public ReadOnly SidebarSubText As Color = Color.FromArgb(255, 221, 156)   ' #FFDD9C

    ' ── Content & Input Colors ───────────────────────────────────
    Public ReadOnly Background As Color = Color.FromArgb(250, 248, 246)      ' Very light warm gray
    Public ReadOnly CardBg As Color = Color.White
    Public ReadOnly InputBg As Color = Color.FromArgb(255, 252, 248)         ' Slight warm tint
    Public ReadOnly BorderLight As Color = Color.FromArgb(230, 225, 220)
    Public ReadOnly TextDark As Color = Color.FromArgb(40, 40, 40)
    Public ReadOnly TextMuted As Color = Color.FromArgb(120, 120, 120)

    ' ── Button States ────────────────────────────────────────────
    Public ReadOnly ButtonPrimary As Color = Color.FromArgb(231, 63, 30)     ' #E73F1E
    Public ReadOnly ButtonHover As Color = Color.FromArgb(251, 108, 0)       ' #FB6C00

End Module
