import React, { useState } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import { jsPDF } from "jspdf";
import "jspdf-autotable";
import TableSortLabel from "@mui/material/TableSortLabel";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogTitle from "@mui/material/DialogTitle";
import Button from "@mui/material/Button";
import './Table.css';

const getStatusStyle = (status) => {
    if (status === "Onaylandi") {
        return { backgroundColor: "#90EE90", color: "green" };
    } else if (status === "Bekliyor") {
        return { backgroundColor: "#FFD700", color: "black" };
    } else if (status === "Reddedildi") {
        return { backgroundColor: "#FF6347", color: "black" };
    } else {
        return { backgroundColor: "#B0C4DE", color: "black" }; // Default color
    }
};

const TableComponent = ({ data, title }) => {
    const [order, setOrder] = useState("asc");
    const [orderBy, setOrderBy] = useState("urunAdi");
    const [openDialog, setOpenDialog] = useState(false);
    const [selectedAction, setSelectedAction] = useState(null);

    const handleRequestSort = (property) => {
        const isAsc = orderBy === property && order === "asc";
        setOrder(isAsc ? "desc" : "asc");
        setOrderBy(property);
    };

    const handleDialogOpen = () => {
        setOpenDialog(true);
    };

    const handleDialogClose = () => {
        setOpenDialog(false);
    };

    const handleActionSelect = (action) => {
        setSelectedAction(action);
        setOpenDialog(false);
        downloadPDF(action);
    };

    const sortedData = [...data].sort((a, b) => {
        if (orderBy === "urunAdi" || orderBy === "islemAdi" || orderBy === "calisanAdi") {
            if (a[orderBy] < b[orderBy]) return order === "asc" ? -1 : 1;
            if (a[orderBy] > b[orderBy]) return order === "asc" ? 1 : -1;
            return 0;
        } else if (orderBy === "urunAdedi" || orderBy === "islemTarihi") {
            if (a[orderBy] < b[orderBy]) return order === "asc" ? -1 : 1;
            if (a[orderBy] > b[orderBy]) return order === "asc" ? 1 : -1;
            return 0;
        }
        return 0;
    });

    const filterDataByAction = (action) => {
        if (!action) return sortedData;
        return sortedData.filter((row) => {
            if (row.islemAdi) {
                return row.islemAdi.toLowerCase().includes(action.toLowerCase());
            }
            return false;
        });
    };

    const downloadPDF = (action) => {
        const doc = new jsPDF();
        const filteredData = filterDataByAction(action);

        if (filteredData.length === 0) {
            alert("Seçilen işlem türüne göre veri bulunmamaktadır.");
            return;
        }

        doc.autoTable({
            head: [
                ["Urun Adi", "Islem Adi", "Tarih", "Calisan Adi", "Adet", "Durum"],
            ],
            body: filteredData.map((row) => [
                row.urunAdi,
                row.islemAdi,
                new Date(row.islemTarihi).toLocaleDateString(),
                row.calisanAdi,
                row.urunAdedi,
                row.durum,
            ]),
            startY: 20,
            margin: { top: 30 },
            theme: "grid",
        });

        if (action == null)
            doc.save(`${title}.pdf`);
        doc.save(`${action}.pdf`);
    };

    return (
        <div className="Table">
            <h3>{title}</h3>
            <TableContainer component={Paper} style={{ boxShadow: "0px 13px 20px 0px #80808029", borderRadius: "12px", background: "#f5f5f5" }}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell>
                                <TableSortLabel
                                    active={orderBy === "urunAdi"}
                                    direction={orderBy === "urunAdi" ? order : "asc"}
                                    onClick={() => handleRequestSort("urunAdi")}
                                    style={{ color: "#00796b" }}
                                >
                                    Ürün Adı
                                </TableSortLabel>
                            </TableCell>
                            <TableCell align="left">
                                <TableSortLabel
                                    active={orderBy === "islemAdi"}
                                    direction={orderBy === "islemAdi" ? order : "asc"}
                                    onClick={() => handleRequestSort("islemAdi")}
                                    style={{ color: "#00796b" }}
                                >
                                    İşlem Adı
                                </TableSortLabel>
                            </TableCell>
                            <TableCell align="left">
                                <TableSortLabel
                                    active={orderBy === "islemTarihi"}
                                    direction={orderBy === "islemTarihi" ? order : "asc"}
                                    onClick={() => handleRequestSort("islemTarihi")}
                                    style={{ color: "#00796b" }}
                                >
                                    Tarih
                                </TableSortLabel>
                            </TableCell>
                            <TableCell align="left">
                                <TableSortLabel
                                    active={orderBy === "calisanAdi"}
                                    direction={orderBy === "calisanAdi" ? order : "asc"}
                                    onClick={() => handleRequestSort("calisanAdi")}
                                    style={{ color: "#00796b" }}
                                >
                                    Çalışan Adı
                                </TableSortLabel>
                            </TableCell>
                            <TableCell align="left">
                                <TableSortLabel
                                    active={orderBy === "urunAdedi"}
                                    direction={orderBy === "urunAdedi" ? order : "asc"}
                                    onClick={() => handleRequestSort("urunAdedi")}
                                    style={{ color: "#00796b" }}
                                >
                                    Adet
                                </TableSortLabel>
                            </TableCell>
                            <TableCell align="left">Durum</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {sortedData.map((row, index) => (
                            <TableRow key={index} style={{ borderRadius: "8px", backgroundColor: "#f0f0f0", marginBottom: "10px" }}>
                                <TableCell>{row.urunAdi}</TableCell>
                                <TableCell align="left">{row.islemAdi}</TableCell>
                                <TableCell align="left">
                                    {new Date(row.islemTarihi).toLocaleDateString()}
                                </TableCell>
                                <TableCell align="left">{row.calisanAdi}</TableCell>
                                <TableCell align="left">{row.urunAdedi}</TableCell>
                                <TableCell align="left">
                                    <span className="status" style={getStatusStyle(row.durum)}>
                                        {row.durum}
                                    </span>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>

            {/* PDF İndirme Butonu */}
            <button className="download-btn" onClick={handleDialogOpen} style={{ background: "#00796b", color: "#fff", padding: "10px 20px", borderRadius: "8px" }}>
                PDF Olarak İndir
            </button>

            {/* Dialog Penceresi */}
            <Dialog open={openDialog} onClose={handleDialogClose}>
                <DialogTitle>İşlem Seçin</DialogTitle>
                <DialogContent>
                    <Button fullWidth onClick={() => handleActionSelect("Giriş")}>
                        Giriş İşlemleri
                    </Button>
                    <Button fullWidth onClick={() => handleActionSelect("Çıkış")}>
                        Çıkış İşlemleri
                    </Button>
                    <Button fullWidth onClick={() => handleActionSelect("İade")}>
                        İade İşlemleri
                    </Button>
                    <Button fullWidth onClick={() => handleActionSelect(null)}>
                        Tüm İşlemler
                    </Button>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleDialogClose} color="primary">
                        Kapat
                    </Button>
                </DialogActions>
            </Dialog>
        </div>
    );
};

export default TableComponent;
